using FootballPredictor.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballPredictor.Web.ViewModels.Matches
{
    public class ListOfResultsViewModel
    {
        public int PageNumber { get; set; }

        public IEnumerable<ListOfMatchesViewModel> Leagues { get; set; }

        public int PreviousPage => this.PageNumber + 1;

        public int NextPage => this.PageNumber - 1;

        public int Gameweek { get; set; }

        public int FirstPage => GlobalConstants.CurrentWeek - 1;

        public bool LastPage => this.Gameweek == 1;

        public bool IsLastPage => this.Gameweek == GlobalConstants.CurrentWeek - 1;
    }
}
