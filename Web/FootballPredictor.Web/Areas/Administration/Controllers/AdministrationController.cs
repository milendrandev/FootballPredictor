namespace FootballPredictor.Web.Areas.Administration.Controllers
{
    using FootballPredictor.Common;
    using FootballPredictor.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
