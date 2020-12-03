namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballPredictor.Web.ViewModels.Users;

    public interface IUsersService
    {
        void AddPointsToUser();

        Task CreateUserInGameweek(int gameweekId, string userId);

        IEnumerable<RankingsViewModel> Rankings();
    }
}
