namespace FitnessSystem.Web.Controllers.Tests
{
    using Moq;
    using NUnit.Framework;
    using Services.Data;
    using TestStack.FluentMVCTesting;

    [TestFixture]

    public class VotesControllerTests
    {
        [Test]
        public void VoteShouldRedirectWithWrongParameters()
        {
            var votesService = new Mock<IVotesServices>();

            var exercisesServiceMock = new Mock<IExercisesServices>();

            var controller = new VotesController(votesService.Object, exercisesServiceMock.Object);
            controller.WithCallTo(x => x.Vote(0, 0))
                .ShouldRedirectTo("/Exercises");
        }
    }
}
