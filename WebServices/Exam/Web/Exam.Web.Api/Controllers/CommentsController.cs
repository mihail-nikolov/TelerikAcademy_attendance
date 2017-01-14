namespace Exam.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.Comment;
    using Services.Data;

    public class CommentsController : ApiController
    {
        private readonly CommentsService comments;

        public CommentsController(CommentsService comments)
        {
            this.comments = comments;
        }

        [Authorize]
        public IHttpActionResult Get(string skip = "0", string take = "10")
        {
            int skipComments;
            if (!int.TryParse(skip, out skipComments))
            {
                skipComments = 0;
            }

            int takeComments;
            if (!int.TryParse(take, out takeComments))
            {
                takeComments = 0;
            }

            if (takeComments > 100)
            {
                takeComments = 100;
            }

            var listedComments = this.comments.GetListedComments(skipComments, takeComments)
              .AsQueryable()
              .ProjectTo<CommentResponseModel>();

            return this.Ok(listedComments);
        }

        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var realEstateResult = this.comments
               .GetCommentDetails(id)
               .ProjectTo<CommentResponseModel>()
               .FirstOrDefault();

            return this.Ok(realEstateResult);
        }

        [HttpGet]
        [Route("api/comments/ByUser/{UserName}")]
        [Authorize]
        public IHttpActionResult GetByUserName(string UserName, string skip = "0", string take = "10")
        {
            int skipComments;
            if (!int.TryParse(skip, out skipComments))
            {
                skipComments = 0;
            }

            int takeComments;
            if (!int.TryParse(take, out takeComments))
            {
                takeComments = 0;
            }

            if (takeComments > 100)
            {
                takeComments = 100;
            }

            var commentsByUser = this.comments.GetListedCommentsByUserName(skipComments, takeComments, UserName)
              .AsQueryable()
              .ProjectTo<CommentResponseModel>();

            return this.Ok(commentsByUser);
        }

        [Authorize]
        public IHttpActionResult Post(CommentRequestModel model)
        {
            var newComment = this.comments.CreateComment(
                model.RealEstateId,
                model.Content,
                this.User.Identity.GetUserId());

            var commentResult = comments
                .GetCommentDetails(newComment.Id)
                .ProjectTo<CommentResponseModel>()
                .FirstOrDefault();

            return this.Created(
                string.Format("/api/Comments/{0}", newComment.Id),
                commentResult);

        }

    }
}