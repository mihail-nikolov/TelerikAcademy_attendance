namespace Teleimot.Web.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.Users;
    using Services.Contracts;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class UsersController : ApiController
    {
        private readonly IUsersService users;
        private readonly IRatingsService ratings;

        public UsersController(IRatingsService ratings, IUsersService users)
        {
            this.users = users;
            this.ratings = ratings;
        }

        //GET: api/Users
        [Route("api/Users/{username}")]
        public IHttpActionResult Get(string username)
        {
            var userQuery = this.users.GetByUserName(username);

            if (!userQuery.Any())
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                        WebApiConstants.NoSuchAUser));
            }

            var user = userQuery.ProjectTo<UserResponseModel>()
                                 .FirstOrDefault();

            return this.Ok(user);
        }

        [Authorize]
        [Route("api/Users/Rate")]
        public IHttpActionResult Post(UserRateRequestModel model)
        {
            try
            {
                IHttpActionResult result;
                if (this.User.Identity.GetUserId() == model.UserId)
                {
                    result = this.BadRequest(WebApiConstants.CannotRateYourself);
                }
                else
                {
                    var newRate = Mapper.Map<Rating>(model);
                    this.ratings.Create(newRate);
                    result = this.Ok();
                }

                return result;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                        e.Message));
            }
        }
    }
}
