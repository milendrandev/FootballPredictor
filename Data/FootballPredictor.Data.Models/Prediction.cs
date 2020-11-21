namespace FootballPredictor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using FootballPredictor.Data.Common.Models;
    using FootballPredictor.Data.Models.Enums;

    public class Prediction : BaseDeletableModel<int>
    {

        public string Description { get; set; }

        public BetType Bet { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }

        public Match Match { get; set; }
    }
}
