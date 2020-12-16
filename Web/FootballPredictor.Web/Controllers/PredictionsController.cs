namespace FootballPredictor.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FootballPredictor.Common;
    using FootballPredictor.Data.Models;
    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.Predictions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PredictionsController : BaseController
    {
        private readonly IPredictionsService predictionsService;
        private readonly UserManager<ApplicationUser> userManager;
        private const int ItemsPerPage = 10;

        public PredictionsController(
            IPredictionsService predictionsService,
            UserManager<ApplicationUser> userManager)
        {
            this.predictionsService = predictionsService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int matchId, string homeTeam, string awayTeam)
        {
            var model = new CreateViewModel
            {
                Id = matchId,
                HomeTeamName = homeTeam,
                AwayTeamName = awayTeam,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            await this.predictionsService.CreateAsync(model.Id, model.HomeGoals, model.AwayGoals, model.Description, user.Id);

            var predictionsCount = this.predictionsService.PredictionsByUserCount(user.Id);
            this.TempData["Message"] = $"You have made {predictionsCount} predictions ! You have left {GlobalConstants.PredictionsLimit - predictionsCount} more";

            return this.Redirect("/Matches/Fixtures");
        }

        public IActionResult All(int id = 1)
        {
            var model = new ListOfPredictionsViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                PredictionsCount = this.predictionsService.PredictionsCount(),
                Predictions = this.predictionsService.All(id, ItemsPerPage),
            };

            return this.View(model);
        }

        [Authorize]
        public IActionResult MyPredictions(int id = 1)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = new ListOfPredictionsViewModel
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                PredictionsCount = this.predictionsService.PredictionsByUserCount(userId),
                Predictions = this.predictionsService.PredictionsByUser(userId, id, ItemsPerPage),
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.predictionsService.DeleteAsync(id, userId);

            return this.Redirect("/Predictions/MyPredictions");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = this.predictionsService.PredictionById(id);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.predictionsService.EditAsync(id, model);

            return this.Redirect("/Predictions/MyPredictions");
        }
    }
}
