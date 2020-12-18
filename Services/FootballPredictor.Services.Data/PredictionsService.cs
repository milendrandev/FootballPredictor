namespace FootballPredictor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FootballPredictor.Common;
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
        private readonly IUsersService usersService;

        public PredictionsService(
            IDeletableEntityRepository<Prediction> predictionRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Match> matchRepository,
            IDeletableEntityRepository<Team> teamRepository,
            IUsersService usersService)
        {
            this.predictionRepository = predictionRepository;
            this.userRepository = userRepository;
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.usersService = usersService;
        }

        public async Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId)
        {
            var predictionsCount = this.PredictionsByUserCount(userId);

            if (predictionsCount >= GlobalConstants.PredictionsLimit)
            {
                return;
            }

            var predictionCreated = this.userRepository.All().Where(u => u.Id.Equals(userId)).Select(u => u.Predictions.Any(p => p.MatchId == id && !p.IsDeleted)).FirstOrDefault();
            if (predictionCreated)
            {
                return;
            }

            var gameweekId = this.matchRepository.All().Where(m => m.Id == id).Select(m => m.GameweekId).FirstOrDefault();

            if (gameweekId < GlobalConstants.CurrentWeek)
            {
                return;
            }

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
                GameweekId = gameweekId,
                UserId = userId,
            };

            await this.usersService.CreateUserInGameweek(gameweekId, userId);

            await this.predictionRepository.AddAsync(prediction);
            await this.predictionRepository.SaveChangesAsync();
        }

        public IEnumerable<PredictionsViewModel> All(int page, int itemsPerPage)
        {
            var predictions = this.predictionRepository.All().ToList();

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
                    UserId = prediction.UserId,
                    GameweekId = prediction.GameweekId,
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
            return this.predictionRepository.All().Where(p => p.UserId.Equals(id) && p.GameweekId == GlobalConstants.CurrentWeek).Count();
        }

        public int PredictionsCount()
        {
            return this.predictionRepository.All().Count();
        }

        public async Task DeleteAsync(int predictionId, string userId)
        {
            var prediction = this.predictionRepository.All().Where(p => p.Id == predictionId).FirstOrDefault();

            this.predictionRepository.Delete(prediction);

            await this.predictionRepository.SaveChangesAsync();
        }

        public CreateViewModel PredictionById(int id)
        {
            var prediction = this.predictionRepository.All().FirstOrDefault(p => p.Id == id);

            var homeTeamId = this.matchRepository.All().Where(m => m.Id == prediction.MatchId).Select(m => m.HomeTeamId).FirstOrDefault();
            var awayTeamId = this.matchRepository.All().Where(m => m.Id == prediction.MatchId).Select(m => m.AwayTeamId).FirstOrDefault();

            var homeTeam = this.teamRepository.All().Where(t => t.Id == homeTeamId).Select(t => t.Name).FirstOrDefault();
            var awayTeam = this.teamRepository.All().Where(t => t.Id == awayTeamId).Select(t => t.Name).FirstOrDefault();

            return new CreateViewModel
            {
                Id = prediction.Id,
                HomeGoals = prediction.HomeTeamGoals,
                AwayGoals = prediction.AwayTeamGoals,
                Description = prediction.Description,
                HomeTeamName = homeTeam,
                AwayTeamName = awayTeam,
            };
        }

        public async Task EditAsync(int id, CreateViewModel model)
        {
            var prediction = this.predictionRepository.All().FirstOrDefault(p => p.Id == id);

            prediction.HomeTeamGoals = model.HomeGoals;
            prediction.AwayTeamGoals = model.AwayGoals;
            prediction.Description = model.Description;

            if (model.HomeGoals > model.AwayGoals)
            {
                prediction.Bet = BetType.Home;
            }
            else if (model.HomeGoals == model.AwayGoals)
            {
                prediction.Bet = BetType.Draw;
            }
            else
            {
                prediction.Bet = BetType.Away;
            }

            this.predictionRepository.Update(prediction);

            await this.predictionRepository.SaveChangesAsync();
        }
    }
}
