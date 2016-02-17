using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem_Kendo.Models
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel
                {
                    ID = book.ID,
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category.Name,
                    Description = book.Description,
                    ISBN = book.ISBN,
                    WebSite = book.WebSite
                };
            }
        }

        public string Author { get;  set; }

        public string Category { get;  set; }

        public string Description { get;  set; }

        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }
    }
}
