namespace FootballPredictor.Web.ViewModels.Teams
{
    using System.Collections.Generic;

    public class TeamDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MatchDetailViewModel> Matches { get; set; }
    }
}
