using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    class CreatureIdentifierTests
    {
        [TestCase]
        public void CreatureIdentifierFromString_ShouldThrowArgumentNullException_WhenNullPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [TestCase]
        public void CreatureIdentifierFromString_ShouldReturnExpectedType_WhenValidStringPassed()
        {
            var identif = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.IsInstanceOf<CreatureIdentifier>(identif);
        }

        [TestCase]
        public void CreatureIdentifierFromString_ShouldReturnExpectedArmyNumber_WhenValidStringPassed()
        {
            var identif = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.AreEqual(identif.ArmyNumber, 1);
        }

        [TestCase]
        public void CreatureIdentifierFromString_ShouldReturnExpectedCreatureType_WhenValidStringPassed()
        {
            var identif = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.AreEqual(identif.CreatureType, "Angel");
        }

        [TestCase]
        public void ToString_ShouldReturnExpectedValue()
        {
            var identif = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            Assert.AreEqual(identif.ToString(), "Angel(1)");
        }
    }
}