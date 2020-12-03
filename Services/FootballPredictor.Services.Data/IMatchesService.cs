namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;

    using FootballPredictor.Web.ViewModels.Matches;

    public interface IMatchesService
    {
        public IEnumerable<ListOfMatchesViewModel> GetAll(int gameweek);

        public IEnumerable<ListOfMatchesViewModel> GetAll(string userId, int gameweek);

        void Simulate();
    }
}
