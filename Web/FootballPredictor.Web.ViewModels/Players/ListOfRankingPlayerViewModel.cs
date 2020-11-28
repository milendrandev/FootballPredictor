namespace FootballPredictor.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListOfRankingPlayerViewModel
    {
        public string LeagueName { get; set; }

        public IEnumerable<RankingPlayerViewModel> Players { get; set; }
    }
}
