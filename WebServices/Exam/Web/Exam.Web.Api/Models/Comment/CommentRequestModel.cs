namespace Exam.Web.Api.Models.Comment
{
    public class CommentRequestModel: BaseCommentModel
    {
        public string UserId { get; set; }

        public int RealEstateId { get; set; }
    }
}