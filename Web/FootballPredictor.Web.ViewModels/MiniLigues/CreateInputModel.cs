namespace FootballPredictor.Web.ViewModels.MiniLigues
{
    using System.ComponentModel.DataAnnotations;

    using FootballPredictor.Data.Models.Enums;

    public class CreateInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public MiniLigueType MiniLigueType { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
