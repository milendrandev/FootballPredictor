using System;
using System.Collections.Generic;
using System.Text;

namespace FootballPredictor.Web.ViewModels.Predictions
{
   public class CreateViewModel
    {
        public int MatchId { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }
    }
}
