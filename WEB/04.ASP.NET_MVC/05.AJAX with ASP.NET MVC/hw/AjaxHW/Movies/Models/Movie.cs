using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required]
        public int LeadingMaleRoleId { get; set; }

        [ForeignKey("LeadingMaleRoleId")]
        public virtual Actor LeadingMaleRole { get; set; }

        [Required]
        public int LeadingFemaleRoleId { get; set; }

        [ForeignKey("LeadingFemaleRoleId")]
        public virtual Actress LeadingFemaleRole { get; set; }

        [Required]
        public int DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual Director Director { get; set; }

        public int StudioId { get; set; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { get; set; }
    }
}