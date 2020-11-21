using FootballPredictor.Data.Models.Enums;

namespace FootballPredictor.Data.Models.ModelsDto.Users
{
    public class UserPredictionsDto
    {
        public int Id { get; set; }

        public BetType Bet { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public int MatchId { get; set; }
    }
}
