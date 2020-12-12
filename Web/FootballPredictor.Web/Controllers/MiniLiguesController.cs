namespace FootballPredictor.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.MiniLigues;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MiniLiguesController : BaseController
    {
        private readonly IMiniLiguesService miniLiguesService;

        public MiniLiguesController(IMiniLiguesService miniLiguesService)
        {
            this.miniLiguesService = miniLiguesService;
        }

        [Authorize]
        public IActionResult All()
        {
            var model = this.miniLiguesService.All();

            return this.View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (model.Password != model.ConfirmPassword)
            {
                this.TempData["Message"] = "Your Confirm Password was differrent from your Password!";
                return this.View();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.miniLiguesService.CreateAsync(model, userId);

            return this.Redirect("/MiniLigues/Dashboard");
        }

        [Authorize]
        public IActionResult Dashboard(string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var member = this.miniLiguesService.IsAMember(id, userId);

            if (!member)
            {
                return this.Redirect("/MiniLigues/All");
            }

            var model = this.miniLiguesService.Dashboard(id);

            return this.View(model);
        }
    }
}
