namespace FitnessSystem.Web.Controllers.Tests
{
    using Moq;
    using NUnit.Framework;
    using Services.Data;
    using TestStack.FluentMVCTesting;

    [TestFixture]

    public class CommentsControllerTests
    {
        public void CommentShouldRedirectWithWrongParameters()
        {
            var commentsServicesMock = new Mock<ICommentsServices>();

            var controller = new CommentsController(commentsServicesMock.Object);
            controller.WithCallTo(x => x.Comment(string.Empty, 0))
                .ShouldRedirectTo("/Exercises");
        }

        public void CommentShouldWorkCorrectly()
        {
            var commentsServicesMock = new Mock<ICommentsServices>();

            var controller = new CommentsController(commentsServicesMock.Object);
            controller.WithCallTo(x => x.Comment("newcomment", 1))
                .ShouldReturnJson();
        }
    }
}
