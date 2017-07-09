namespace Teleimot.Data.Models
{
    using BaseModels;
    using System.ComponentModel.DataAnnotations;
    using Teleimot.Common;

    public class Rating : BaseModel<int>
    {
        [Required]
        [Range(RatingConstants.MinRating, RatingConstants.MaxRating)]
        public int Value { get; set; }

        //[ForeignKey("UserId")]
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
