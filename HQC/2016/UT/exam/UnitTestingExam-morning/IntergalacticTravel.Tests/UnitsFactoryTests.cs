namespace IntergalacticTravel.Tests
{
    using Exceptions;
    using NUnit.Framework;

    [TestFixture]
    class UnitsFactoryTests
    {
        private UnitsFactory unitsFactory;

        [SetUp]
        public void SetUpFactory()
        {
            unitsFactory = new UnitsFactory();
        }

        [TestCase]
        public void GetUnit_shouldRreturnProcyon_WhenValidCommand()
        {
            var procyon = this.unitsFactory.GetUnit("create unit Procyon Gosho 1");

            Assert.AreEqual(procyon.GetType().Name, typeof(Procyon).Name);
        }

        [TestCase]
        public void GetUnit_shouldRreturnLuyten_WhenValidCommand()
        {
            var luyten = this.unitsFactory.GetUnit("create unit Luyten Pesho 2");

            Assert.AreEqual(luyten.GetType().Name, typeof(Luyten).Name);
        }

        [TestCase]
        public void GetUnit_shouldRreturnLacaille_WhenValidCommand()
        {
            var lacaille = this.unitsFactory.GetUnit("create unit Lacaille Tosho 3");

            Assert.AreEqual(lacaille.GetType().Name, typeof(Lacaille).Name);
        }

        [TestCase]
        public void GetUnit_shouldThrowInvalidUnitCreationCommandException_WhenInValidUnit()
        {
            Assert.Throws<InvalidUnitCreationCommandException>(() => this.unitsFactory.GetUnit("create unit Dog Tosho 3"));
        }

        [TestCase]
        public void GetUnit_shouldThrowInvalidUnitCreationCommandException_WhenInValidUnitId()
        {
            Assert.Throws<InvalidUnitCreationCommandException>(() => this.unitsFactory.GetUnit("create unit Lacaille Tosho three"));
        }
    }
}
