namespace Teleimot.Data.Models
{
    using BaseModels;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Comment : BaseModel<int>
    {
        [Required]
        [StringLength(CommentConstants.ContentMaxLength, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}
