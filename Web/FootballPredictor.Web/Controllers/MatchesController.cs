namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Common;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.Matches;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : BaseController
    {
        private readonly IMatchesService matchesService;
        private readonly IUsersService usersService;

        public MatchesController(IMatchesService matchesService, IUsersService usersService)
        {
            this.matchesService = matchesService;
            this.usersService = usersService;
        }

        public IActionResult Fuxtures(int id = 1)
        {
            var gameweek = GlobalConstants.CurrentWeek + id - 1;
            var viewModel = new ListOfLeaguesViewModel
            {
                PageNumber = id,
                Gameweek = gameweek,
                Leagues = this.matchesService.GetAll(gameweek),
            };

            return this.View(viewModel);
        }

        public IActionResult Results(int id = 1)
        {
            var gameweek = GlobalConstants.CurrentWeek - id;
            var viewModel = new ListOfResultsViewModel
            {
                PageNumber = id,
                Gameweek = gameweek,
                Leagues = this.matchesService.GetAll(gameweek),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Simulate()
        {
            this.matchesService.Simulate();

            return this.Redirect("/Matches/All");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult UserPoints()
        {
            this.usersService.AddPointsToUser();

            return this.Redirect("/");
        }
    }
}
