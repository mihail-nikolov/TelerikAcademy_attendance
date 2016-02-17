using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessSystem.Web.Controllers
{
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
            return this.RedirectToAction("Index", "Categories");
        }
    }
}