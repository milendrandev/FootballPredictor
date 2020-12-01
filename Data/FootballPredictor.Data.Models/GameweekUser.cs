namespace FootballPredictor.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FootballPredictor.Data.Common.Models;

    public class GameweekUser : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(Gameweek))]
        public int GameweekId { get; set; }

        public Gameweek Gameweek { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int UserPoints { get; set; }
    }
}
