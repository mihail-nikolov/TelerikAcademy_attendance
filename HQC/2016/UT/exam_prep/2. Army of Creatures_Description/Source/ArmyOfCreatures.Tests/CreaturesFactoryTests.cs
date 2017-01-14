using System;
using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class CreaturesFactoryTests
    {
        [TestCase("Angel")]
        [TestCase("AncientBehemoth")]
        [TestCase("CyclopsKing")]
        [TestCase("Goblin")]
        [TestCase("Griffin")]
        [TestCase("WolfRaider")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void CreateCreature_withGivenAngelCreature_ShouldReturnAngel(string name)
        {
            var factory = new ExtendedCreatureFactory();
            var created = factory.CreateCreature(name);
            Assert.AreEqual(created.GetType().Name, name);
        }

        [TestCase]
        public void CreateCreature_withWrongName_shouldThrowArgumentException()
        {
            // arr
            var factory = new ExtendedCreatureFactory();

            Assert.Throws<ArgumentException>(() => factory.CreateCreature("Kuche"));
        }
    }
}
