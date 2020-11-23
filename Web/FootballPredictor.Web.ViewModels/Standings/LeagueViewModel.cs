using System;
using System.Collections.Generic;
using System.Text;

namespace FootballPredictor.Web.ViewModels.Standings
{
    public class LeagueViewModel
    {
        public string Name { get; set; }

        public ICollection<TeamViewModel> Teams { get; set; }
    }
}
