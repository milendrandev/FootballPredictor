namespace FootballPredictor.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

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
        private const int ItemsPerPage = 1;

        public PredictionsController(IPredictionsService predictionsService, UserManager<ApplicationUser> userManager)
        {
            this.predictionsService = predictionsService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create(int matchId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var predictionsCount = this.predictionsService.PredictionsByUserCount(user.Id);

            if (predictionsCount > 5)
            {
                return this.Redirect("/");
            }

            var model = new CreateViewModel
            {
                Id = matchId,
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

            return this.Redirect("/Matches/All");
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
    }
}
