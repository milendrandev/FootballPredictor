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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
            var creatorId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.miniLiguesService.RemoveAsync(id, creatorId);

            return this.Redirect("/MiniLigues/MyMiniLigues");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.miniLiguesService.RemoveAsync(userId, id);
            return this.Redirect("/MiniLigues/MyMiniLigues");
        }

        [Authorize]
        public IActionResult Join(string id)
        {
            var miniLigueName = this.miniLiguesService.MiniLigueName(id);
            var model = new JoinViewModel
            {
                Id = id,
                Name = miniLigueName,
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Join(JoinViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (this.miniLiguesService.IsAMember(model.Id, userId))
            {
                var miniLigueName = this.miniLiguesService.MiniLigueName(model.Id);
                model.Name = miniLigueName;
                this.TempData["Message"] = "You are already a member of this League!";
                return this.View(model);
            }
            else if (!this.miniLiguesService.IsCorrectPassword(model.Id, model.Password))
            {
                var miniLigueName = this.miniLiguesService.MiniLigueName(model.Id);
                model.Name = miniLigueName;
                this.TempData["Message"] = "Invalid Password!";
                return this.View(model);
            }

            await this.miniLiguesService.Join(model, userId);

            return this.Redirect("/MiniLigues/MyMiniLigues");
        }

        [Authorize]
        public IActionResult MyMiniLigues()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = this.miniLiguesService.MiniLiguesByUser(userId);

            return this.View(model);
        }
    }
}
