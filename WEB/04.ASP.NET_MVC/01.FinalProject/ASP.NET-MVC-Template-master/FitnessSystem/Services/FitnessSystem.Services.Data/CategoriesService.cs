namespace FitnessSystem.Services.Data
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

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderByDescending(x => x.ModifiedOn).ThenByDescending(c => c.CreatedOn);
        }

        public void Create(Category newCategory)
        {
            this.categories.Add(newCategory);
            this.categories.Save();
        }

        public void Update(Category categoryToUpdate)
        {
            var category = this.categories.GetById(categoryToUpdate.Id);
            category.IsVisible = categoryToUpdate.IsVisible;
            category.Name = categoryToUpdate.Name;
            this.categories.Update(category);
            this.categories.Save();
        }

        public void Delete(int id)
        {
            var category = this.categories.GetById(id);
            this.categories.Delete(category);
            this.categories.Save();
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public IQueryable<Category> GetAllVisible()
        {
            return this.categories.All().Where(c => c.IsVisible == true).OrderBy(x => x.Name);
        }

        public bool IfExists(string name)
        {
            var categories = this.categories.All().Where(c => c.Name == name).ToList();
            if (categories.Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}
