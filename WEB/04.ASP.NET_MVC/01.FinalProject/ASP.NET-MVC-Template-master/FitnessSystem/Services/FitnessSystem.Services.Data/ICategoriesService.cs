namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
