namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetAllVisible();

        void Create(Category newCategory);

        void Update(Category categoryToUpdate);

        void AddExercise(Exercise newExercise);

        bool IfExists(string name);

        void Delete(int id);

        Category GetById(int id);
    }
}
