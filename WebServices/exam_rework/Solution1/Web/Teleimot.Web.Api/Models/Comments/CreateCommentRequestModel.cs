namespace Teleimot.Web.Api.Models.Comments
{
    using Data.Models;
    using Infrastructure;
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentRequestModel: BaseCommentModel, IMapFrom<Comment>
    {
        [Required]
        public int RealEstateId { get; set; }
    }
}