namespace FootballPredictor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using FootballPredictor.Data.Common.Models;
    using FootballPredictor.Data.Models.Enums;

    public class Match : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(Team))]
        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(Team))]
        public int AwayTeamId { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }

        public int GameWeek { get; set; }

        [ForeignKey(nameof(League))]
        public int LeagueId { get; set; }

        public League League { get; set; }

        public BetType ResultType { get; set; }
    }
}
