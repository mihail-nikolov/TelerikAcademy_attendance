namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ArticlesController : Controller
    {
        // GET: Administration/Articles
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
