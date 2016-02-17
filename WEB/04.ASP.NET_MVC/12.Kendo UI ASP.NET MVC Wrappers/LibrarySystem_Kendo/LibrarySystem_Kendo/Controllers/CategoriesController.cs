using LibrarySystem_Kendo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem_Kendo.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public ApplicationDbContext dbContext;

        public CategoriesController()
        {
            this.dbContext = new ApplicationDbContext();
        }
        // GET: Categories
        public ActionResult Index()
        {
            var categories = this.dbContext.Categories.OrderBy(c => c.ID);
            return View(categories);
        }
    }
}