namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ExercisesController : Controller
    {
        // GET: Administration/Exercises
        public ActionResult Index()
        {
            return this.View();
        }
    }
}