namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Services.Data;
    using FootballPredictor.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Rankings()
        {
            var model = new EnumRankingsViewModel
            {
                Rankings = this.usersService.Rankings(),
            };

            return this.View(model);
        }
    }
}
