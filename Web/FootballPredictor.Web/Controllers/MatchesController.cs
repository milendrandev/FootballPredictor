﻿namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

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
            var id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = this.matchesService.GetAll(id);

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
