namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageVideosController : Controller
    {
        // GET: Administration/Videos
        public ActionResult Index()
        {
            return this.View();
        }
    }
}