using LibrarySystem_Kendo.Data;
using LibrarySystem_Kendo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem_Kendo.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;

        public HomeController()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var categories = this.dbContext.Categories.ToList();
            return View(categories);
        }
        
        public JsonResult GetAutocompleteData(string text)
        {
            var selectedBooks = this.dbContext.Books.Where(x => x.Title.ToLower().Contains(text.ToLower())).Select(BookViewModel.FromBook);
           // var selectedBooks = this.dbContext.Books.Where(x => x.Title.ToLower().Contains(text.ToLower())).Select(b => b.Title);
            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var books = this.dbContext.Books.Where(b => b.Title.Contains(search)).ToList();
            return View(books);
        }
    }
}