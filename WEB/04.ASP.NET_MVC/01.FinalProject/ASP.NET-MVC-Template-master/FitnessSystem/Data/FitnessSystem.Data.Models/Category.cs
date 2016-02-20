namespace FitnessSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
