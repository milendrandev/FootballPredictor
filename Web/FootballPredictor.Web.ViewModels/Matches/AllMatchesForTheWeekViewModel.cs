namespace FootballPredictor.Web.ViewModels.Matches
{
    public class AllMatchesForTheWeekViewModel
    {
        public AllMatchesForTheWeekViewModel()
        {
            this.PredictionCreated = false;
        }

        public int Id { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public int GameWeek { get; set; }

        public bool PredictionCreated { get; set; }
    }
}
