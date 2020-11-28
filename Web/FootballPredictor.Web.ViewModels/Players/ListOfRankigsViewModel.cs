namespace FootballPredictor.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListOfRankigsViewModel
    {
        public IEnumerable<ListOfRankingPlayerViewModel> Leagues { get; set; }
    }
}
