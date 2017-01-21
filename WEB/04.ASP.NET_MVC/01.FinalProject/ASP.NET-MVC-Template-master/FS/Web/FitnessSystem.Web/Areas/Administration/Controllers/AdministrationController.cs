namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using FitnessSystem.Common;
    using FitnessSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
