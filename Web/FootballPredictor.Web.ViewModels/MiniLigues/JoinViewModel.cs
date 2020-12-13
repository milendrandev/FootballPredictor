namespace FootballPredictor.Web.ViewModels.MiniLigues
{
    using System.ComponentModel.DataAnnotations;

    public class JoinViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string Password { get; set; }
    }
}
