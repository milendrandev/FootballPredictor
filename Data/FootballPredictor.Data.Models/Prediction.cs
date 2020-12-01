namespace FootballPredictor.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FootballPredictor.Data.Common.Models;
    using FootballPredictor.Data.Models.Enums;

    public class Prediction : BaseDeletableModel<int>
    {

        public string Description { get; set; }

        public BetType Bet { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public bool IsPredictedResult { get; set; }

        public bool IsPredictedHomeGoals { get; set; }

        public bool IsPredictedAwayGoals { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }

        public Match Match { get; set; }

        [ForeignKey(nameof(Gameweek))]
        public int GameweekId { get; set; }

        public Gameweek Gameweek { get; set; }
    }
}
