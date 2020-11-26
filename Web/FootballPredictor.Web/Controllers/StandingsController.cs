namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.Standings;
    using Microsoft.AspNetCore.Mvc;

    public class StandingsController : BaseController
    {
        private readonly IStandingsService standingsService;
        private readonly ITeamsService teamsService;

        public StandingsController(IStandingsService standingsService, ITeamsService teamsService)
        {
            this.standingsService = standingsService;
            this.teamsService = teamsService;
        }

        public IActionResult Leagues()
        {
             return this.View();
        }

        public IActionResult EnglishPremierLeague()
        {
            var leagueName = "English Premier League";
            var model = this.standingsService.LeagueStandings(leagueName);

            return this.View("LeagueStandings", model);
        }

        public IActionResult GermanBundesliga()
        {
            var leagueName = "German 1. Bundesliga";
            var model = this.standingsService.LeagueStandings(leagueName);

            return this.View("LeagueStandings", model);
        }

        public IActionResult ItalianSerieA()
        {
            var leagueName = "Italian Serie A";
            var model = this.standingsService.LeagueStandings(leagueName);

            return this.View("LeagueStandings", model);
        }

        public IActionResult SpainPrimeraDivision()
        {
            var leagueName = "Spain Primera Division";
            var model = this.standingsService.LeagueStandings(leagueName);

            return this.View("LeagueStandings", model);
        }
    }
}
