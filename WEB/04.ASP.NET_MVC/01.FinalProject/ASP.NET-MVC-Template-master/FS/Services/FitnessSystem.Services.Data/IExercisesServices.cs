namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Models;

    public interface IExercisesServices
    {
        IQueryable<Exercise> GetAll();

        IQueryable<Exercise> Get(int number);

        Exercise GetById(int id);

        int GetVotesById(int id);

        IQueryable<Exercise> GetByUser(string id);

        void Create(Exercise newExercise);

        void Update(Exercise exerciseToUpdate);

        void ChangeCategory(Exercise exerciseToUpdate);

        void Delete(int id);
    }
}
