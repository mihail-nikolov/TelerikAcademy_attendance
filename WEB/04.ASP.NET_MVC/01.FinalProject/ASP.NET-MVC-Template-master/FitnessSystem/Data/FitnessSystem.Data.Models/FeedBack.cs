namespace FitnessSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Feedback : BaseModel<int>
    {
        [Required]
        [StringLength(15, ErrorMessage = "max len:{0}, min len{2}.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = " min len: {0}")]
        public string Content { get; set; }
    }
}
