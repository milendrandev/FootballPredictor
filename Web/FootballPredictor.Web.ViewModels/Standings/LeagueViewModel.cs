namespace FootballPredictor.Web.ViewModels.Standings
{
    using System.Collections.Generic;

    public class LeagueViewModel
    {
        public string Name { get; set; }

        public ICollection<TeamViewModel> Teams { get; set; }
    }
}
