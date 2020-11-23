namespace FootballPredictor.Services.Data
{
    using System.Collections.Generic;

    using FootballPredictor.Web.ViewModels.Standings;

    public interface IStandingsService
    {
        LeagueViewModel LeagueStandings(string leagueName);
    }
}
