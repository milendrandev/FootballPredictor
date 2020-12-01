namespace FootballPredictor.Web.ViewModels.Predictions
{
    public class PredictionsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public string Username { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }
    }
}
