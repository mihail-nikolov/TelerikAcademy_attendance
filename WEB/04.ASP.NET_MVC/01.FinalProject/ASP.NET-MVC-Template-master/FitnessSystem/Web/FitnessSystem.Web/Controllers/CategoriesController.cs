namespace FitnessSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using FitnessSystem.Services.Data;

    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = this.categories.GetAll().ToList();
            return this.View(categories);
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