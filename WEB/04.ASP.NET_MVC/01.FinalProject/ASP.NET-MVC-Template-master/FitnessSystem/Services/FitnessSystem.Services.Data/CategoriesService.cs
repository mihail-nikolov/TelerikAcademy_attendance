namespace FitnessSystem.Services.Data
{
    using System;
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

        public void Create(Category newCategory)
        {
            this.categories.Add(newCategory);
            this.categories.Save();
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderByDescending(x => x.CreatedOn);
        }

        public void Update(Category categoryToUpdate)
        {
            var category = this.categories.GetById(categoryToUpdate.Id);
            category.IsVisible = categoryToUpdate.IsVisible;
            category.Name = categoryToUpdate.Name;
            this.categories.Save();
        }
    }
}
