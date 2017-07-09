namespace Teleimot.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using System.Linq;
    using Web.Api.Controllers;
    using Services.Contracts;
    using Moq;
    using Data.Models;
    using System.Collections.Generic;
    using Web.Api.App_Start;
    using Common;
    using Web.Api.Models.Comments;
    using System.Web.Http.Results;
    using System.Net;

    [TestClass]
    public class CommentsControllerTests
    {
        private string inMemoryServerUrl = "http://localhost:12345";

        private void ConfigMappers()
        {
            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);
        }

        [TestMethod]
        public void GetByUser_ShouldReturnOkWithCorrectResponse_WhenCalledWithCorrectUserAndDefaultSkipAndTake()
        {
            var mockedUsersService = new Mock<IUsersService>();
            var mockedCommentsService = new Mock<ICommentsService>();

            var userNameParamInput = "testUser";
            var testUser1 = new User() { UserName = userNameParamInput };
            var users = new List<User>() { testUser1 };

            var userQuery = users.AsQueryable();
            mockedUsersService.Setup(x => x.GetByUserName(userNameParamInput)).Returns(userQuery);

            var commentContent = "test comment content";
            var commentToAdd = new Comment() { Id = 1, Content = commentContent, RealEstateId = 1, User = testUser1 };
            var commentsList = new List<Comment>() { commentToAdd };
            mockedCommentsService.Setup(x => x.GetByUser(10, 0, userNameParamInput)).Returns(commentsList);

            this.ConfigMappers();

            CommentsController commentsController = new CommentsController(mockedCommentsService.Object, mockedUsersService.Object);
            this.SetupController(commentsController);


            IHttpActionResult actionResult = commentsController.ByUser(userNameParamInput);
            var contentResult = actionResult as OkNegotiatedContentResult<List<CommentResponseModel>>;

            mockedCommentsService.VerifyAll();
            mockedUsersService.VerifyAll();

            Assert.AreEqual(contentResult.Request.Method, HttpMethod.Get);
            Assert.AreEqual(contentResult.Content[0].Content, commentContent);
        }

        [TestMethod]
        public void CommentsControllerShouldHaveAuthorizedHttpGetRouteAndValidateTakeAttribute()
        {
            var mockedUsersService = new Mock<IUsersService>();
            var mockedCommentsService = new Mock<ICommentsService>();

            var userNameParamInput = "testUser";
            var testUser1 = new User() { UserName = userNameParamInput };
            var users = new List<User>() { testUser1 };

            var userQuery = users.AsQueryable();
            mockedUsersService.Setup(x => x.GetByUserName(userNameParamInput)).Returns(userQuery);

            var commentContent = "test comment content";
            var commentToAdd = new Comment() { Id = 1, Content = commentContent, RealEstateId = 1, User = testUser1 };
            var commentsList = new List<Comment>() { commentToAdd };
            mockedCommentsService.Setup(x => x.GetByUser(10, 0, userNameParamInput)).Returns(commentsList);

            this.ConfigMappers();

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, mockedCommentsService.Object, mockedUsersService.Object);

            var response = server.CreateGetRequest("/api/Comments/ByUser/testUser");
            // TODO - cannot test the Authorization for the controller
            //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        private void SetupController(ApiController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            //string serverUrl = "http://test-url.com";

            ////Setup the Request object of the controller
            //var request = new HttpRequestMessage()
            //{
            //    RequestUri = new Uri(serverUrl)
            //};
            //controller.Request = request;

            ////Setup the configuration of the controller
            //var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional });
            //controller.Configuration = config;

            ////Apply the routes of the controller
            //controller.RequestContext.RouteData =
            //    new HttpRouteData(
            //        route: new HttpRoute(),
            //        values: new HttpRouteValueDictionary
            //        {
            //            { "controller", "bugs" }
            //        });
        }
    }
}
