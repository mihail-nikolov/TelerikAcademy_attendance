namespace FitnessSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ExercisesController : Controller
    {
        // GET: Exercises
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult MyExercises()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }
    }
}
