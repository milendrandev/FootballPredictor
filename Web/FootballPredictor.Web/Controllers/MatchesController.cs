using FootballPredictor.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPredictor.Web.Controllers
{
    public class MatchesController : BaseController
    {
        private readonly IMatchesService matchesService;

        public MatchesController(IMatchesService matchesService)
        {
            this.matchesService = matchesService;
        }
        public IActionResult All()
        {
            var viewModel = this.matchesService.GetAll();

            return this.View(viewModel);
        }
    }
}
