namespace FitnessSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Vote : BaseModel<int>
    {
        [Required]
        public int Points { get; set; }

        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
