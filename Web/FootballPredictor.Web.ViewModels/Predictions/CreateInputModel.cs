using FootballPredictor.Data.Models.Enums;

namespace FootballPredictor.Web.ViewModels.Predictions
{
    public class CreateInputModel
    {
        public int MatchId { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public BetType Bet { get; set; }

        public string Description { get; set; }
    }
}
