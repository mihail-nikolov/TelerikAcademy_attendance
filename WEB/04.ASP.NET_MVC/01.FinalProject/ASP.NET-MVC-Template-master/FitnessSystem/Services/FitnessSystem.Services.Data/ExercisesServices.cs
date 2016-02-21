namespace FitnessSystem.Services.Data
{
    using System;
    using System.Linq;

    using FitnessSystem.Data.Common;
    using FitnessSystem.Data.Models;

    public class ExercisesServices : IExercisesServices
    {
        private readonly IDbRepository<Exercise> exercises;

        public ExercisesServices(IDbRepository<Exercise> exercises)
        {
            this.exercises = exercises;
        }

        public IQueryable<Exercise> GetAll()
        {
            return this.exercises.All().OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Exercise> Get(int number)
        {
            return this.exercises.All().OrderByDescending(x => x.Votes.Sum(v => v.Points)).Take(number);
        }

        public void Create(Exercise newExercise)
        {
            this.exercises.Add(newExercise);
            this.exercises.Save();
        }

        public void Update(Exercise updatedExercise)
        {
            var exercise = this.exercises.GetById(updatedExercise.Id);
            exercise.Title = updatedExercise.Title;
            exercise.Content = updatedExercise.Content;
            exercise.CategoryId = updatedExercise.CategoryId;
            this.exercises.Save();
        }

        public void Delete(int id)
        {
            var exercise = this.exercises.GetById(id);
            this.exercises.Delete(exercise);
            this.exercises.Save();
        }

        public Exercise GetById(int id)
        {
            return this.exercises.GetById(id);
        }

        public IQueryable<Exercise> GetByUser(string id)
        {
            return this.exercises.All().Where(x => x.AuthorId == id).OrderByDescending(x => x.CreatedOn);
        }

        public void ChangeCategory(Exercise exerciseToUpdate)
        {
            var exercise = this.exercises.GetById(exerciseToUpdate.Id);
            exercise.CategoryId = exerciseToUpdate.CategoryId;
            this.exercises.Save();
        }

        public int GetVotesById(int id)
        {
            int exerciseVotes = 0;
            var exercise = this.exercises.GetById(id);
            if (exercise.Votes.Any())
            {
                exerciseVotes = exercise.Votes.Sum(v => v.Points);
            }

            return exerciseVotes;
        }
    }
}
