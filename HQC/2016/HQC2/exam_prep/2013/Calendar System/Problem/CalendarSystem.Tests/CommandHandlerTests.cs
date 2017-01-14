namespace CalendarSystem.Tests
{
    using CalendarSystem.Engine;
    using CalendarSystem.Events.Contracts;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CommandHandlerTests
    {
        [Test]
        public void Parse_ShouldThrowException_WhenInvalidFormat()
        {
            Mock<IEventsManager> mockedManager = new Mock<IEventsManager>();
            var handler = new CommandHandler(mockedManager.Object);

            Assert.That(() => handler.Parse("AddEvent"), Throws.Exception.With.Message.Contains("Invalid command"));
        }

        [Test]
        public void Parse_ShouldWorkCorrectly()
        {
            Mock<IEventsManager> mockedManager = new Mock<IEventsManager>();
            var handler = new CommandHandler(mockedManager.Object);
            var command = handler.Parse("command arg-1 | arg 2");

            Assert.AreEqual(command.CommandName, "command");
            Assert.AreEqual(command.Parameters[0], "arg-1");
            Assert.AreEqual(command.Parameters[1], "arg 2");
        }
    }
}
