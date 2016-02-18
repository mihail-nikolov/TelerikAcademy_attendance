namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Common;
    using System.Web.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageExercisesController : Controller
    {
        // GET: Administration/Exercises
        public ActionResult Index()
        {
            return this.View();
        }
    }
}