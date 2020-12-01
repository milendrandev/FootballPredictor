namespace FootballPredictor.Services.Data
{
    using System.Linq;

    using FootballPredictor.Common;
    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Match> matchRepository;
        private readonly IDeletableEntityRepository<Prediction> predictionRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Match> matchRepository,
            IDeletableEntityRepository<Prediction> predictionRepository)
        {
            this.userRepository = userRepository;
            this.matchRepository = matchRepository;
            this.predictionRepository = predictionRepository;
        }

        public void AddPointsToUser()
        {
            var users = this.userRepository.All().ToList();

            var matches = this.matchRepository.AllAsNoTracking().Where(m => m.GameweekId == GlobalConstants.CurrentWeek).ToList();

            foreach (var user in users)
            {
                var predictions = this.predictionRepository.All().Where(p => p.UserId.Equals(user.Id)).ToList();

                foreach (var prediction in predictions)
                {
                    var match = matches.Where(m => m.Id == prediction.MatchId).FirstOrDefault();

                    if (match == null)
                    {
                        continue;
                    }

                    if (match.ResultType == prediction.Bet)
                    {
                        user.UserPoints += 10;

                        if (match.HomeGoals == prediction.HomeTeamGoals && match.AwayGoals == prediction.AwayTeamGoals)
                        {
                            user.UserPoints += 40;
                        }
                        else if (match.HomeGoals == prediction.HomeTeamGoals)
                        {
                            user.UserPoints += 10;
                        }
                        else if (match.AwayGoals == prediction.AwayTeamGoals)
                        {
                            user.UserPoints += 10;
                        }
                    }
                }

                this.userRepository.Update(user);
            }

            this.userRepository.SaveChanges();
        }
    }
}
