namespace FitnessSystem.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using Data.Models;
    using Exercises;
    using Infrastructure.Mapping;

    public class CategoryWithExercisesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ExerciseLinkModel> Exercises { get; set; }
    }
}
