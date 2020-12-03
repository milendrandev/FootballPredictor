using System.Collections.Generic;

namespace FootballPredictor.Web.ViewModels.Users
{
    public class RankingsViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int UserPoints { get; set; }

        public IEnumerable<int> Gameweeks { get; set; }

        public IEnumerable<int> GameweekPoints { get; set; }
    }
}
