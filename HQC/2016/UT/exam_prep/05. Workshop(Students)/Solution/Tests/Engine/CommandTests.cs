namespace Tests.Engine
{
    using NUnit.Framework;
    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ReturnsNewCommand_WhenValidInput()
        {
            var command = Command.Parse("AddCat Here Cool");
            Assert.IsInstanceOf<Command>(command);
            Assert.AreEqual(command.Name, "AddCat");
        }

        [Test]
        public void Parse_FillsCorrectlyNameAndParameters_WhenValidInput()
        {
            var command = Command.Parse("AddCat Here Cool");
            Assert.AreEqual(command.Name, "AddCat");
            Assert.AreEqual(command.Parameters.Count, 2);
        }

        [Test]
        public void Parse_FillsOnlyName_whenOnlyOneWordInInput()
        {
            var command = Command.Parse("AddCat");
            Assert.AreEqual(command.Name, "AddCat");
            Assert.AreEqual(command.Parameters, null);
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidName_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            // Arrange
            var invalidInput = " ForMale Cool";

            // Act && Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }
    }
}