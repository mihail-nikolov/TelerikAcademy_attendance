namespace FitnessSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(2, ErrorMessage = "min len: {1}")]
        public string Content { get; set; }

        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
