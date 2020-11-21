using System;
using System.Collections.Generic;
using System.Text;

namespace FootballPredictor.Web.ViewModels.Matches
{
    public class AllMatchesForTheWeekViewModel
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public int GameWeek { get; set; }
    }
}
