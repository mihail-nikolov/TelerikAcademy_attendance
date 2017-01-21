namespace FitnessSystem.Web.ViewModels.Exercises
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ExerciseEditViewModel : IMapFrom<Exercise>, IMapTo<Exercise>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "min len: {1}")]
        public string Title { get; set; }

        [UIHint("tinymce_full")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Required]
        [MinLength(15, ErrorMessage = "min len: {1}")]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
