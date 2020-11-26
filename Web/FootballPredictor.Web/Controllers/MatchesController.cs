namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : BaseController
    {
        private readonly IMatchesService matchesService;
        private readonly IUsersService calculateService;

        public MatchesController(IMatchesService matchesService, IUsersService calculateService)
        {
            this.matchesService = matchesService;
            this.calculateService = calculateService;
        }

        public IActionResult All()
        {
            var viewModel = this.matchesService.GetAll();

            return this.View(viewModel);
        }

        public IActionResult Simulate()
        {
            this.matchesService.Simulate();
            this.calculateService.AddPointsToUser();

            return this.Redirect("/Matches/All");
        }
    }
}
