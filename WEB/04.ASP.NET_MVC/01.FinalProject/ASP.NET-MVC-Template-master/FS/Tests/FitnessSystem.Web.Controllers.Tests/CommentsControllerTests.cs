namespace FitnessSystem.Web.Controllers.Tests
{
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data;
    using TestStack.FluentMVCTesting;

    [TestFixture]

    public class CommentsControllerTests
    {
        [Test]
        public void CommentShouldRedirectWithWrongParameters()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(CommentsController).Assembly);

            var commentsServicesMock = new Mock<ICommentsServices>();

            var controller = new CommentsController(commentsServicesMock.Object);
            controller.WithCallTo(x => x.Comment(string.Empty, 0))
                .ShouldRedirectTo("/Exercises");
        }
    }
}
