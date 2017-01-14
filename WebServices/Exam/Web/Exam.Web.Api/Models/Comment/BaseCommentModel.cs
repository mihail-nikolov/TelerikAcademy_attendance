namespace Exam.Web.Api.Models.Comment
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class BaseCommentModel
    {
        [MinLength(RealEstateConstants.CommentMinLength)]
        [MaxLength(RealEstateConstants.CommentMaxLength)]
        public string Content { get; set; }
    }
}