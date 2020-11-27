namespace FootballPredictor.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.Predictions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PredictionsController : BaseController
    {
        private readonly IPredictionsService predictionsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PredictionsController(IPredictionsService predictionsService, UserManager<ApplicationUser> userManager)
        {
            this.predictionsService = predictionsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create(int matchId)
        {
            var model = new CreateViewModel
            {
                Id = matchId,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);

            await this.predictionsService.CreateAsync(model.Id, model.HomeGoals, model.AwayGoals, model.Description, user.Id);
            return this.Redirect("/Matches/All");
        }

        public IActionResult All()
        {
            var model = this.predictionsService.All();

            return this.View(model);
        }

        public IActionResult MyPredictions()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = this.predictionsService.PredictionsByUser(userId);

            return this.View(model);
        }
    }
}
