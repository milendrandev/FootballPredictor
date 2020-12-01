namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballPredictor.Data.Common.Repositories;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Data.Models.Enums;
    using FootballPredictor.Web.ViewModels.Predictions;

    public class PredictionsService : IPredictionsService
    {
        private readonly IDeletableEntityRepository<Prediction> predictionRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Match> matchRepository;
        private readonly IDeletableEntityRepository<Team> teamRepository;

        public PredictionsService(
            IDeletableEntityRepository<Prediction> predictionRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Match> matchRepository,
            IDeletableEntityRepository<Team> teamRepository)
        {
            this.predictionRepository = predictionRepository;
            this.userRepository = userRepository;
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
        }

        public async Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId)
        {
            var bet = String.Empty;
            if (homeGoals > awayGoals)
            {
                bet = "Home";
            }
            else if (homeGoals == awayGoals)
            {
                bet = "Draw";
            }
            else
            {
                bet = "Away";
            }

            var prediction = new Prediction
            {
                MatchId = id,
                HomeTeamGoals = homeGoals,
                AwayTeamGoals = awayGoals,
                Bet = (BetType)Enum.Parse(typeof(BetType), bet),
                Description = description,
                UserId = userId,
            };

            await this.predictionRepository.AddAsync(prediction);
            await this.predictionRepository.SaveChangesAsync();
        }

        public IEnumerable<PredictionsViewModel> All(int page, int itemsPerPage)
        {
            var predictions = this.predictionRepository.AllAsNoTracking().ToList();

            var listOfPredictions = new List<PredictionsViewModel>();

            foreach (var prediction in predictions)
            {
                var match = this.matchRepository.All().Where(m => m.Id == prediction.MatchId).FirstOrDefault();
                var homeTeamName = this.teamRepository.All().Where(t => t.Id == match.HomeTeamId).Select(t => t.Name).FirstOrDefault();
                var awayTeamName = this.teamRepository.All().Where(t => t.Id == match.AwayTeamId).Select(t => t.Name).FirstOrDefault();
                var username = this.userRepository.All().Where(u => u.Id == prediction.UserId).Select(u => u.UserName).FirstOrDefault();

                var predictionModel = new PredictionsViewModel
                {
                    Id = prediction.Id,
                    HomeTeamName = homeTeamName,
                    AwayTeamName = awayTeamName,
                    HomeTeamGoals = prediction.HomeTeamGoals,
                    AwayTeamGoals = prediction.AwayTeamGoals,
                    Description = prediction.Description,
                    Username = username,
                };
                listOfPredictions.Add(predictionModel);
            }

            var sorted = listOfPredictions.OrderByDescending(p => p.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

            return sorted;
        }

        public IEnumerable<PredictionsViewModel> PredictionsByUser(string id, int pageId, int itemsPerPage)
        {
            var user = this.userRepository.All().Where(u => u.Id == id).FirstOrDefault();

            var userPredictions = this.All(pageId, itemsPerPage).Where(p => p.Username == user.UserName);

            return userPredictions;
        }

        public int PredictionsByUserCount(string id)
        {
            return this.predictionRepository.All().Where(p => p.UserId.Equals(id)).Count();
        }

        public int PredictionsCount()
        {
            return this.predictionRepository.AllAsNoTracking().Count();
        }
    }
}
