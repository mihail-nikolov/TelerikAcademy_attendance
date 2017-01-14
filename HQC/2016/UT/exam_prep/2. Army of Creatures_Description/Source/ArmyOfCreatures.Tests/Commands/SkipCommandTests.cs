namespace ArmyOfCreatures.Tests.Commands
{
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Tests.Mocked;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using System;

    [TestFixture]
    class SkipCommandTests
    {
        [TestCase]
        public void AddCreatures_ShouldThrowArgumentNullException_WhenNullCreatureIdentifier()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);
            Assert.Throws<ArgumentNullException>(() => manager.AddCreatures(null, 1));
        }
    }
}
