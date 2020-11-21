namespace FootballPredictor.Services.Data
{
    using System.Linq;
    using System.Text;

    using FootballPredictor.Data.Common.Models;
    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;

    public class UserPointsCalculateService : IUserPointsCalculateService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Match> matchRepository;

        public UserPointsCalculateService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Match> matchRepository)
        {
            this.userRepository = userRepository;
            this.matchRepository = matchRepository;
        }
        public void AddPointsToUser()
        {
            var users = this.userRepository.All().ToList();

            var matches = this.matchRepository.AllAsNoTracking().Where(m => m.GameWeek == 1).ToList();

            foreach (var user in users)
            {
                foreach (var prediction in user.Predictions)
                {
                    var match = matches.Where(m => m.Id == prediction.MatchId).FirstOrDefault();

                    if (match == null)
                    {
                        continue;
                    }

                    if (match.ResultType == prediction.Bet)
                    {
                        user.UserPoints += 10;
                    }

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

                this.userRepository.Update(user);
            }
            this.userRepository.SaveChanges();
        }
    }
}
