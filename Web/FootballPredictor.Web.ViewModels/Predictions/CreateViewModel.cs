using System.ComponentModel.DataAnnotations;

namespace FootballPredictor.Web.ViewModels.Predictions
{
    public class CreateViewModel
    {
        public int Id { get; set; }

        [Range(0, 10)]
        [Display(Name = "Home Goals")]
        public int HomeGoals { get; set; }

        [Range(0, 10)]
        [Display(Name = "Away Goals")]
        public int AwayGoals { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
