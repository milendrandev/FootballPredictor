using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPredictor.Web.Controllers
{
    public class PlayersController : BaseController
    {
        public IActionResult Squad()
        {
            return this.View();
        }
    }
}
