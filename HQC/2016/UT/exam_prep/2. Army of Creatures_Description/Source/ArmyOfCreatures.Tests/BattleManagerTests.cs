namespace ArmyOfCreatures.Tests
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
    class BattleManagerTests
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
        public void AddCreatures_FactoryCallCreateCreature_WhenValidIdentifierPassed()
        {
            var logger = new Mock<ILogger>();
            var factory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(factory.Object, logger.Object);

            var fixture = new Fixture();
            fixture.Customizations.Add(
                new TypeRelay(
                    typeof(Creature),
                    typeof(Angel)));
            var creature = fixture.Create<Creature>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            factory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
            manager.AddCreatures(identifier, 1);

            factory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Once);
        }

        [TestCase]
        public void AddCreatures_LoggerWriteLineShouldBecalled_WhenValidIdentifierPassed()
        {
            var mockedlogger = new Mock<ILogger>();
            var mockedfactory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(mockedfactory.Object, mockedlogger.Object);

            var fixture = new Fixture();
            fixture.Customizations.Add(
                new TypeRelay(
                    typeof(Creature),
                    typeof(Angel)));
            var creature = fixture.Create<Creature>();
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            mockedfactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
            mockedlogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            manager.AddCreatures(identifier, 1);

            mockedlogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
        // ---------------------------------------------------------------------------------------------------------------------------------------
        [TestCase]
        public void Attack_ShouldThrowArgumentException_WhenAttackerIdentifierNull()
        {
            var mockedlogger = new Mock<ILogger>();
            var mockedfactory = new Mock<ICreaturesFactory>();
            var manager = new MockedBattleManager(mockedfactory.Object, mockedlogger.Object);
            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            CreaturesInBattle crInBattleAngle = new CreaturesInBattle(new Angel(), 1);

            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");
            CreaturesInBattle crInBattleBehemoth = new CreaturesInBattle(new Behemoth(), 1);
            manager.Creatures.Add(crInBattleBehemoth);

            Assert.Throws<ArgumentException>(() => manager.Attack(attackerIdentifier, defenderIdentifier));
        }

        [TestCase]
        public void Attack_ShouldThrowArgumentException_WhenDefenderIdentifierNull()
        {
            var mockedlogger = new Mock<ILogger>();
            var mockedfactory = new Mock<ICreaturesFactory>();
            var manager = new MockedBattleManager(mockedfactory.Object, mockedlogger.Object);
            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            CreaturesInBattle crInBattleAngle = new CreaturesInBattle(new Angel(), 1);
            manager.Creatures.Add(crInBattleAngle);

            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");
            CreaturesInBattle crInBattleBehemoth = new CreaturesInBattle(new Behemoth(), 1);

            Assert.Throws<ArgumentException>(() => manager.Attack(attackerIdentifier, defenderIdentifier));
            //ThrowsAssert
        }

        [TestCase]
        public void Attack_ShouldCallLWriteline4Times_WhenAttackSuccessful()
        {
            var mockedlogger = new Mock<ILogger>();
            var mockedfactory = new Mock<ICreaturesFactory>();
            var manager = new MockedBattleManager(mockedfactory.Object, mockedlogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            CreaturesInBattle crInBattleAngle = new CreaturesInBattle(new Angel(), 1);
            manager.Creatures.Add(crInBattleAngle);

            manager.Attack(identifier, identifier);

            mockedlogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        [TestCase]
        public void Skip_ShouldThrowArgumentNullException_WhenNullIdentif()
        {
            //var mockedlogger = new Mock<ILogger>();
            //var mockedfactory = new Mock<ICreaturesFactory>();
            //var manager = new MockedBattleManager(mockedfactory.Object, mockedlogger.Object);
            //var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            //CreaturesInBattle crInBattleAngle = new CreaturesInBattle(new Angel(), 1);
            //manager.Creatures.Add(crInBattleAngle);

            //manager.Attack(identifier, identifier);

            //mockedlogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        [TestCase]
        public void Skip_ShouldCallLoggerOnce_WhenValid()
        {
            //var mockedlogger = new Mock<ILogger>();
            //var mockedfactory = new Mock<ICreaturesFactory>();
            //var manager = new MockedBattleManager(mockedfactory.Object, mockedlogger.Object);
            //var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            //CreaturesInBattle crInBattleAngle = new CreaturesInBattle(new Angel(), 1);
            //manager.Creatures.Add(crInBattleAngle);

            //manager.Attack(identifier, identifier);

            //mockedlogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        //TODO think about how to test the protected methods
    }
}
