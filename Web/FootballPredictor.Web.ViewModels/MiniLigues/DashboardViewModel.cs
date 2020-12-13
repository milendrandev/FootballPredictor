namespace FootballPredictor.Web.ViewModels.MiniLigues
{
    using System.Collections.Generic;

    using FootballPredictor.Web.ViewModels.Users;

    public class DashboardViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<RankingsViewModel> Users { get; set; }
    }
}
