using System.ComponentModel.DataAnnotations;

namespace FootballPredictor.Web.ViewModels.Predictions
{
    public class CreateViewModel
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }
    }
}
