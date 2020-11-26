namespace FootballPredictor.Web.Controllers
{
    using FootballPredictor.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : BaseController
    {
        private readonly ITeamsService teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            this.teamsService = teamsService;
        }

        public IActionResult Squad(int id)
        {
            var model = this.teamsService.GetSquad(id);

            return this.View(model);
        }

        public IActionResult Team(int id)
        {
            var model = this.teamsService.TeamDetails(id);

            return this.View("TeamDetails", model);
        }
    }
}
