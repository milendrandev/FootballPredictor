namespace FootballPredictor.Services.Data
{
    using System.Threading.Tasks;

    public interface IPredictionsService
    {
        Task CreateAsync(int id, int homeGoals, int awayGoals, string description, string userId);
    }
}
