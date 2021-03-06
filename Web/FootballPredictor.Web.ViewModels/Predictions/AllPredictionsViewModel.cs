﻿namespace FootballPredictor.Web.ViewModels.Predictions
{
    using FootballPredictor.Data.Models.Enums;

    public class AllPredictionsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public BetType Bet { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int MatchId { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }
    }
}
