namespace FootballPredictor.Web.ViewModels.Matches
{
    using System.Collections.Generic;

    public class ListOfLeaguesViewModel
    {
        public int PageNumber { get; set; }

        public IEnumerable<ListOfMatchesViewModel> Leagues { get; set; }

        public int ThisUserPredictionsCount { get; set; }

        public int PreviousPage => this.PageNumber - 1;

        public int NextPage => this.PageNumber + 1;

        public int Gameweek { get; set; }

        public bool LastPage => this.Gameweek == 38;
    }
}
