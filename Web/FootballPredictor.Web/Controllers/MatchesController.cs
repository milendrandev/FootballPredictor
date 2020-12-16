namespace FootballPredictor.Web.Controllers
{
    using System.Security.Claims;

    using FootballPredictor.Common;
    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.Matches;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : BaseController
    {
        private readonly IMatchesService matchesService;
        private readonly IUsersService usersService;
        private readonly IPredictionsService predictionsService;

        public MatchesController(IMatchesService matchesService, IUsersService usersService, IPredictionsService predictionsService)
        {
            this.matchesService = matchesService;
            this.usersService = usersService;
            this.predictionsService = predictionsService;
        }

        public IActionResult Fixtures(int id = 1)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var gameweek = GlobalConstants.CurrentWeek + id - 1;
                var viewModel = new ListOfLeaguesViewModel
                {
                    PageNumber = id,
                    Gameweek = gameweek,
                    Leagues = this.matchesService.GetAll(userId, gameweek),
                    ThisUserPredictionsCount = this.predictionsService.PredictionsByUserCount(userId),
                };

                return this.View(viewModel);
            }
            else
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

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Simulate()
        {
            this.matchesService.Simulate();

            return this.Redirect("/Matches/Fixtures");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult UserPoints()
        {
            this.usersService.AddPointsToUser();

            return this.Redirect("/");
        }
    }
}
