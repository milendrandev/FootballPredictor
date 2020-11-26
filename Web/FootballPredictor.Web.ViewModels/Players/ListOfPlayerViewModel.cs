namespace FootballPredictor.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListOfPlayerViewModel
    {
        public virtual IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
