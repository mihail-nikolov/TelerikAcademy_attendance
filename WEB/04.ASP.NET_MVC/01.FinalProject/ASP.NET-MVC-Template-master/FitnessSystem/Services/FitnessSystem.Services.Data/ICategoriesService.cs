namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        void Create(Category newCategory);

        void Update(Category categoryToUpdate);
    }
}
