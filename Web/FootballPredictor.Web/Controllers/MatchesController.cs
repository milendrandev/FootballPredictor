﻿namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Data.Models;
    using FootballPredictor.Services.Data;
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

        public IActionResult All()
        {
            var viewModel = this.matchesService.GetAll();

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
