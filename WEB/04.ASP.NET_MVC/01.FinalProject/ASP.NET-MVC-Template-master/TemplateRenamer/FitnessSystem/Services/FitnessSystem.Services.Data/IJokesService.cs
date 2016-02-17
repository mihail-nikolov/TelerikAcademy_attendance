namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
