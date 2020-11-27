namespace FootballPredictor.Web.ViewModels.Matches
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListOfLeaguesViewModel
    {
        public IEnumerable<ListOfMatchesViewModel> Leagues { get; set; }
    }
}
