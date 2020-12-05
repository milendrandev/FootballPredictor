namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballPredictor.Web.ViewModels.Predictions;

    public interface IPredictionsService
    {
        Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId);

        IEnumerable<PredictionsViewModel> All(int page, int itemsPerPage);

        IEnumerable<PredictionsViewModel> PredictionsByUser(string id, int pageId, int itemsPerPage);

        int PredictionsByUserCount(string id);

        int PredictionsCount();

        public void Delete(int predictionId, string userId);
    }
}
