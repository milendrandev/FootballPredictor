namespace FootballPredictor.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FootballPredictor.Data.Common.Models;

    public class MiniLigueUser : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(MiniLigue))]
        public string MiniLigueId { get; set; }

        public MiniLigue MiniLigue { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
