namespace FitnessSystem.Data.Models
{
    using FitnessSystem.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Exercise : BaseModel<int>
    {
        public Exercise()
        {
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [MinLength(3, ErrorMessage = "min len: {1}")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(15, ErrorMessage = "min len: {1}")]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
