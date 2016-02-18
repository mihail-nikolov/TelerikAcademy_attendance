namespace FitnessSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Create()
        {
            return this.PartialView("_CreateCategoryPartial");
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }
    }
}