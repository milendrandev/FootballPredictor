namespace FootballPredictor.Web.ViewModels.Players
{
    using System.Collections.Generic;

    public class ListOfPlayerViewModel
    {
        public string TeamName { get; set; }

        public virtual IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
