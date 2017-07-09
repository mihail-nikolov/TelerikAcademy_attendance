namespace Teleimot.Web.Api.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class BaseCommentModel
    {
        [Required]
        [StringLength(CommentConstants.ContentMaxLength, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; }
    }
}