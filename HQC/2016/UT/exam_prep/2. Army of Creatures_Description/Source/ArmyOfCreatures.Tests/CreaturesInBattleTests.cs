namespace ArmyOfCreatures.Tests
{
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using Logic.Creatures;    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class CreaturesInBattleTests
    {
        [TestCase]
        public void AddCreatures_ShouldThrowArgumentNullException_WhenNullCreatureIdentifier()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);
            Assert.Throws<ArgumentNullException>(() => manager.AddCreatures(null, 1));
        }

        [TestCase]
        public void DealDamageShouldThrowArgumentNullException_WhenDefenderNull()
        {
            var ang = new Angel();
            var crInBattle = new CreaturesInBattle(ang, 2);
            var defender = new Mock<ICreaturesInBattle>();
            crInBattle.DealDamage(defender.Object);
        }

        [TestCase]
        public void DealDamageShouldDoTheCorrectDamageToTheDefender()
        {
            var ang = new Angel();
            var crInBattle = new CreaturesInBattle(ang, 2);
            var defender = new Mock<ICreaturesInBattle>();
            defender.SetupGet(x => x.CurrentDefense).Returns(20);
            defender.SetupSet(x => x.TotalHitPoints = 20);
            defender.SetupGet(x => x.Creature).Returns(() => new Devil());

            crInBattle.DealDamage(defender.Object);
            defender.Verify(x => x.TotalHitPoints, Times.Once);
        }

        [TestCase]
        public void Skip_ShouldCallApplyCorrectDefense()
        {
            var ang = new Angel();
            var crInBattle = new CreaturesInBattle(ang, 2);
            crInBattle.Skip();
            Assert.AreEqual(crInBattle.PermanentDefense, ang.Defense + 3);
        }

        [TestCase]
        public void StartNewTurn_ShouldWriteTheCorrectValues()
        {
            var ang = new Angel();
            var crInBattle = new CreaturesInBattle(ang, 2);
            crInBattle.StartNewTurn();
            Assert.AreEqual(crInBattle.PermanentAttack, ang.Attack);
            Assert.AreEqual(crInBattle.PermanentDefense, ang.Defense);
        }

    }
}