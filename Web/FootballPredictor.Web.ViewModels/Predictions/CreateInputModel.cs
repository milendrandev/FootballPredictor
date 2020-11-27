namespace FootballPredictor.Web.ViewModels.Predictions
{
    using System.ComponentModel.DataAnnotations;

    public class CreateInputModel
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public int HomeGoals { get; set; }

        [Range(0, 10)]
        public int AwayGoals { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
