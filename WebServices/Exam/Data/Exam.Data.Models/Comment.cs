namespace Exam.Data.Models
{
    using Exam.Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        [MinLength(RealEstateConstants.CommentMinLength)]
        [MaxLength(RealEstateConstants.CommentMaxLength)]
        public string Content { get; set; }

        //[Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreatedOn { get; set; }

        //[Required]
        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

    }
}
