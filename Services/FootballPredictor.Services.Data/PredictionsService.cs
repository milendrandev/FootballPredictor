using FootballPredictor.Data.Common.Repositories;
using FootballPredictor.Data.Models;
using FootballPredictor.Data.Models.Enums;
using FootballPredictor.Data.Models.ModelsDto.Users;
using FootballPredictor.Web.ViewModels.Predictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPredictor.Services.Data
{
    public class PredictionsService : IPredictionsService
    {
        private readonly IDeletableEntityRepository<Prediction> predictionRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Match> matchRepository;

        public PredictionsService(
            IDeletableEntityRepository<Prediction> predictionRepository
            , IDeletableEntityRepository<ApplicationUser> userRepository
            , IDeletableEntityRepository<Match> matchRepository)
        {
            this.predictionRepository = predictionRepository;
            this.userRepository = userRepository;
            this.matchRepository = matchRepository;
        }
        public async Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId)
        {
            var bet = "";
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
            };

            await this.predictionRepository.AddAsync(prediction);
            await this.predictionRepository.SaveChangesAsync();

        }

    }
}
