namespace FootballPredictor.Web.ViewModels.MiniLigues
{
    using System.ComponentModel.DataAnnotations;

    public class CreateInputModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string Password { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string ConfirmPassword { get; set; }
    }
}
