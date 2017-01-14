namespace ArmyOfCreatures.Tests.Commands
{
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Console.Commands;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class AddCommandTests
    {
        [TestCase]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenNullmanager()
        {
            var manager = new Mock<IBattleManager>();
            var addCom = new AddCommand();
            string[] arguments = new string[] { "10", "AncientBehemoth(1)" };

            Assert.Throws<ArgumentNullException>(() => addCom.ProcessCommand(null, arguments));
        }

        [TestCase]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenNullargs()
        {
            var manager = new Mock<IBattleManager>();
            var addCom = new AddCommand();
            string[] arguments = new string[] { "10", "AncientBehemoth(1)" };

            Assert.Throws<ArgumentNullException>(() => addCom.ProcessCommand(manager.Object, null));
        }

        [TestCase]
        public void ProcessCommand_ShouldPass()
        {
            var manager = new Mock<IBattleManager>();
            var addCom = new AddCommand();
            string[] arguments = new string[] { "10", "AncientBehemoth(1)" };

            manager.Setup(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()));
            addCom.ProcessCommand(manager.Object, arguments);

            manager.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Once);
        }
    }
}
