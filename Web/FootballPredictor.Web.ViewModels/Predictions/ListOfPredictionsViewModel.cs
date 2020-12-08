namespace FootballPredictor.Web.ViewModels.Predictions
{
    using System.Collections.Generic;

    public class ListOfPredictionsViewModel
    {
        public int PageNumber { get; set; }

        public int PreviousPage => this.PageNumber - 1;

        public int NextPage => this.PageNumber + 1;

        public bool LastPage => this.PageNumber * this.ItemsPerPage >= this.PredictionsCount;

        public int ItemsPerPage { get; set; }

        public int PredictionsCount { get; set; }

        public IEnumerable<PredictionsViewModel> Predictions { get; set; }
    }
}
