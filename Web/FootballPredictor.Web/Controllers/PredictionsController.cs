
using FootballPredictor.Services.Data;
using FootballPredictor.Web.ViewModels.Predictions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPredictor.Web.Controllers
{
    public class PredictionsController : BaseController
    {
        private readonly IPredictionsService predictionsService;

        public PredictionsController(IPredictionsService predictionsService)
        {
            this.predictionsService = predictionsService;
        }
        [HttpGet]
        public IActionResult Create(string homeTeam, string awayTeam, int matchId)
        {
            var model = new CreateViewModel
            {
                MatchId = matchId,
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task <IActionResult> Create(int id,int homeGoals, int awayGoals,string description)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.predictionsService.CreateAsync(id,homeGoals, awayGoals,description);
            return this.Redirect("/Matches/All");
        }

        public IActionResult All()
        {
            return this.View();
        }

    }
}
