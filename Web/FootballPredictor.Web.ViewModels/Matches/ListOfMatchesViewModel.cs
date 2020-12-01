namespace FootballPredictor.Web.ViewModels.Matches
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListOfMatchesViewModel
    {
        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public IEnumerable<AllMatchesForTheWeekViewModel> Matches { get; set; }
    }
}
