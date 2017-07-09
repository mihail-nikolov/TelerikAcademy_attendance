namespace Teleimot.Web.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.Comments;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Services.Contracts;

    
    public class CommentsController : ApiController
    {
        private readonly ICommentsService comments;
        private readonly IUsersService users;

        public CommentsController(ICommentsService comments, IUsersService users)
        {
            this.comments = comments;
            this.users = users;
        }

        [Authorize]
        [HttpGet]
        [Route("api/comments/ByUser")]
        public IHttpActionResult ByUser(string UserName, int skip = 0, int take = 10)
        {
            var userQuery = this.users.GetByUserName(UserName);

            if (!userQuery.Any())
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                        WebApiConstants.NoSuchAUser));
            }

            int toTake = this.DecideTake(take);
            List<CommentResponseModel> commentsResult = this.comments.GetByUser(take, skip, UserName)
                                                            .AsQueryable()
                                                            .ProjectTo<CommentResponseModel>().ToList();
            return this.Ok(commentsResult);
        }

        //[ValidateTake] ??
        public IHttpActionResult Get(int id, int skip = 0, int take = 10)
        {
            int toTake = this.DecideTake(take);

            IQueryable commentsResult = this.comments.GetByRealEstate(take, skip, id)
                                                     .AsQueryable()
                                                     .ProjectTo<CommentResponseModel>();

            return this.Ok(commentsResult);
        }

        // POST: api/Comments
        //[ValidateModel] ??
        public IHttpActionResult Post(CreateCommentRequestModel model)
        {
            try
            {
                var newComment = Mapper.Map<Comment>(model);
                newComment.UserId = this.User.Identity.GetUserId();
                var createdCommentId = this.comments.Create(newComment);

                var commentResult = this.comments.GetDetailsById(createdCommentId)
                                                 .AsQueryable()
                                                 .ProjectTo<CommentResponseModel>()
                                                 .FirstOrDefault();

                return this.Created("/api/Comments", commentResult);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                       e.Message));
            }
        }

        private int DecideTake(int take)
        {
            if (take > WebApiConstants.MaxEntitiesToTake)
            {
                take = WebApiConstants.MaxEntitiesToTake;
            }

            return take;
        }
    }
}
