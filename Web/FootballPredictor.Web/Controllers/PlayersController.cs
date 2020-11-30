namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : BaseController
    {
        private readonly IPlayersService playersService;

        public PlayersController(IPlayersService playersService)
        {
            this.playersService = playersService;
        }

        [Authorize]
        public IActionResult Rankings()
        {
            var model = this.playersService.Rankings();

            return this.View(model);
        }
    }
}
