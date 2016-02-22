namespace FitnessSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Exercise : BaseModel<int>
    {
        public Exercise()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MinLength(3, ErrorMessage = "min len: {1}")]
        public string Title { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "min len: {1}")]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
