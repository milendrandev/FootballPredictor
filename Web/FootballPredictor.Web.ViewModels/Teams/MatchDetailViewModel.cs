namespace FootballPredictor.Web.ViewModels.Teams
{
    public class MatchDetailViewModel
    {
        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }

        public int Gameweek { get; set; }
    }
}
