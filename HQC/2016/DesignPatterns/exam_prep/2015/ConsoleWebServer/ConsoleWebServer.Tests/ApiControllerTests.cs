//namespace ConsoleWebServer.Tests
//{
//    using NUnit.Framework;
//    using Framework;
//    using Moq;
//    using Application.Controllers;
//    using System.Collections.Generic;
//    [TestFixture]
//    class ApiControllerTests
//    {
//        [Test]
//        public void ReturnMe_ShouldReturnNewActionReultWithTHeGivneParameter()
//        {
//            var mockedHttpRequest = new Mock<IHttpRequest>();
//            var apiController = new ApiController(mockedHttpRequest.Object);
//            var parameter = "parameter";
//            var actionResult = apiController.ReturnMe(parameter);

//            Assert.AreEqual(actionResult.GetType().Name, "JsonActionResult");
//            //Assert.AreEqual(actionResult., "IActionResult");
//        }

//        [Test]
//        public void GetDateWithCors_ShouldReturnJsonActionResultWithCorsWithCorrectParameters()
//        {
//            string domainName = "domainName";
//            var mockedHttpRequest = new Mock<IHttpRequest>();
//            var mockedHeaders = new Dictionary<string, ICollection<string>>();
//            mockedHeaders.Add("Referer", new List<string> { domainName });

//            mockedHttpRequest.SetupGet(x => x.Headers).Returns(mockedHeaders);

//            var apiController = new ApiController(mockedHttpRequest.Object);
//            var resultWithCors = apiController.GetDateWithCors(domainName);

//            mockedHttpRequest.VerifyAll();
//            mockedHttpRequest.Verify(x => x.Headers, Times.Exactly(2));
//            Assert.AreEqual(resultWithCors.GetType().Name, "JsonActionResultWithCors");
//        }

//        [Test]
//        public void GetDateWithCors_ShouldThrowAnException()
//        {
//            string domainName = "domainName";
//            var mockedHttpRequest = new Mock<IHttpRequest>();
//            var mockedHeaders = new Dictionary<string, ICollection<string>>();
//            mockedHeaders.Add("something", new List<string> { });

//            mockedHttpRequest.SetupGet(x => x.Headers).Returns(mockedHeaders);

//            var apiController = new ApiController(mockedHttpRequest.Object);

//            Assert.That(() => apiController.GetDateWithCors(domainName), Throws.ArgumentException.With.Message.Contains("Invalid referer"));
//        }
//    }
//}
