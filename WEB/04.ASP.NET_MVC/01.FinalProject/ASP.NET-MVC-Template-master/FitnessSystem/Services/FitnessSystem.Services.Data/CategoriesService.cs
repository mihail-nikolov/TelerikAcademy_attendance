﻿namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Common;
    using FitnessSystem.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<Category> categories;

        public CategoriesService(IDbRepository<Category> categories)
        {
            this.categories = categories;
        }

        //public Category EnsureCategory(string name)
        //{
        //    var category = this.categories.All().FirstOrDefault(x => x.Name == name);
        //    if (category != null)
        //    {
        //        return category;
        //    }

        //    category = new Category { Name = name };
        //    this.categories.Add(category);
        //    this.categories.Save();
        //    return category;
        //}

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
