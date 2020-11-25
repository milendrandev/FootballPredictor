namespace FootballPredictor.Web.ViewModels.Standings
{
   public class TeamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Looses { get; set; }

        public int ScoredGoals { get; set; }

        public int ConcededGoals { get; set; }

        public int MatchesPlayed { get; set; }

    }
}
