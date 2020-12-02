namespace FootballPredictor.Web.ViewModels.Matches
{
    public class AllMatchesForTheWeekViewModel
    {

        public int Id { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }

        public int GameweekId { get; set; }

        public bool PredictionCreated { get; set; }
    }
}
