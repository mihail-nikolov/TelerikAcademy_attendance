namespace ArmyOfCreatures.Tests.Commands
{
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Tests.Mocked;
    using Console.Commands;    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using System;

    [TestFixture]
    class CommandManagerTests
    {
        [TestCase]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenNullmanager()
        {
            var manager = new Mock<IBattleManager>();
            var comMan = new CommandManager();
            string commandLine = "add 10 AncientBehemoth(1)";

            Assert.Throws<ArgumentNullException>(() => comMan.ProcessCommand(commandLine, null));
        }

        [TestCase]
        public void ProcessCommand_ShouldThrowArgumentException_WhenwrongCom()
        {
            var manager = new Mock<IBattleManager>();
            var comMan = new CommandManager();
            string commandLine = "bla 10 AncientBehemoth(1)";

            Assert.Throws<ArgumentException>(() => comMan.ProcessCommand(commandLine, manager.Object));
        }

        [TestCase]
        public void ProcessCommand_ShouldPass()
        {
            var manager = new Mock<IBattleManager>();
            var comMan = new CommandManager();
            string commandLine = "add 10 AncientBehemoth(1)";

            manager.Setup(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()));
            comMan.ProcessCommand(commandLine, manager.Object);

            manager.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Once);
        }
    }
}
