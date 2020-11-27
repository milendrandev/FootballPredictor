namespace FootballPredictor.Services.Data
{
    using System.Threading.Tasks;

    using FootballPredictor.Web.ViewModels.Predictions;

    public interface IPredictionsService
    {
        Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId);

        ListOfPredictionsViewModel All();

        ListOfPredictionsViewModel PredictionsByUser(string id);
    }
}
