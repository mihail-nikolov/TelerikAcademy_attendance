namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

       // Category EnsureCategory(string name);
    }
}
