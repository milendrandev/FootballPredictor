namespace FootballPredictor.Web.ViewModels.Predictions
{
    using System.Collections.Generic;

    public class ListOfPredictionsViewModel
    {
        public IEnumerable<PredictionsViewModel> Predictions { get; set; }
    }
}
