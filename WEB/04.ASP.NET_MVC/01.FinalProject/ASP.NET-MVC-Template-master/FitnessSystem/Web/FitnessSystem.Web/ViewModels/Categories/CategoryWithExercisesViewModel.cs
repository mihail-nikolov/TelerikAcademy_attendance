namespace FitnessSystem.Web.ViewModels.Categories
{
    using Data.Models;
    using Exercises;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class CategoryWithExercisesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ExerciseLinkModel> Exercises { get; set; }
    }
}