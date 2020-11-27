namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;

    using FootballPredictor.Web.ViewModels.Matches;

    public interface IMatchesService
    {
        ListOfLeaguesViewModel GetAll(string id);

        void Simulate();
    }
}
