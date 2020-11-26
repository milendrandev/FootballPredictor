using System;
using System.Collections.Generic;
using System.Text;

namespace FootballPredictor.Web.ViewModels.Matches
{
    public class ListOfLeaguesViewModel
    {
        public IEnumerable<ListOfMatchesViewModel> Leagues { get; set; }
    }
}
