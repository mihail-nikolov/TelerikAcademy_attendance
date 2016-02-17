using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem_Kendo.Models
{
    public class CategoryGridViewModel
    {
        public static Expression<Func<Category, CategoryGridViewModel>> FromCategory
        {
            get
            {
                return cat => new CategoryGridViewModel
                {
                    Id = cat.ID,
                    Name = cat.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}