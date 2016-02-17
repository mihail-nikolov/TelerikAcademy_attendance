using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LibrarySystem_Kendo.Data;
using LibrarySystem_Kendo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace LibrarySystem_Kendo.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        public ApplicationDbContext dbContext;

        public BooksController()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            this.CategoriesDropDown();
            return View();
        }

        private void CategoriesDropDown()
        {
            var categories = this.dbContext.Categories
                 .Select(CategoryGridViewModel.FromCategory).OrderBy(s => s.Name);

            this.ViewData["categories"] = categories;
            this.ViewData["defaultCategory"] = categories.First();
        }

        public JsonResult Create([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                //int bookId = int.Parse(book.Category);
                // var category = this.dbContext.Categories.FirstOrDefault(x => x.ID == bookId);
                var category = this.dbContext.Categories.FirstOrDefault(x => x.Name == book.Category);
                var newBook = new Book
                {
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category = category,
                    ISBN = book.ISBN,
                    WebSite = book.WebSite
                };

                this.dbContext.Books.Add(newBook);
                this.dbContext.SaveChanges();

                book.ID = newBook.ID;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            var existingBook = this.dbContext.Books.FirstOrDefault(x => x.ID == book.ID);
            var category = this.dbContext.Categories.FirstOrDefault(x => x.Name == book.Category);
            if (book != null && ModelState.IsValid)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.WebSite = book.WebSite;
                existingBook.Category = category;

                //int bookId = int.Parse(book.Category);
                // existingBook.Category = this.dbContext.Categories.FirstOrDefault(x => x.ID == bookId);
                book.Category = category.Name;
                this.dbContext.SaveChanges();
            }

            return Json((new[] { book }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Destroy([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            var existingBook = this.dbContext.Books.FirstOrDefault(x => x.ID == book.ID);

            this.dbContext.Books.Remove(existingBook);
            this.dbContext.SaveChanges();

            return Json(new[] { book }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var books = this.dbContext.Books
                .Select(BookViewModel.FromBook)
                .AsQueryable()
                .ToDataSourceResult(request);
            return this.Json(books);
        }

        public ActionResult Details(string id)
        {
            int bookID;
            if (!int.TryParse(id, out bookID))
            {
                Response.Redirect("/");
            }
            var book = this.dbContext.Books.FirstOrDefault(b => b.ID == bookID);
            return View(book);
        }
    }
}