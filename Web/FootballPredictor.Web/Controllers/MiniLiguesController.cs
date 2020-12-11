using FootballPredictor.Services.Data;
using FootballPredictor.Web.ViewModels.MiniLigues;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPredictor.Web.Controllers
{
    public class MiniLiguesController : BaseController
    {
        private readonly IMiniLiguesService miniLiguesService;

        public MiniLiguesController(IMiniLiguesService miniLiguesService)
        {
            this.miniLiguesService = miniLiguesService;
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

            await this.miniLiguesService.CreateAsync(model);

            return this.Redirect("/MiniLigues/");
        }
    }
}
