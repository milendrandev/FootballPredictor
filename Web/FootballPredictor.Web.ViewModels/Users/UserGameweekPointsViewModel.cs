namespace FootballPredictor.Web.ViewModels.Users
{
    using System.Collections.Generic;

    public class UserGameweekPointsViewModel
    {
        public string Username { get; set; }

        public int TotalPoints { get; set; }

        public IEnumerable<GameweekPointsViewModel> GameweekPoints { get; set; }
    }
}
