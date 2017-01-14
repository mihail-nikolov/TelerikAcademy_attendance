namespace IntergalacticTravel.Tests
{
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class UnitTests
    {
        private Unit unit;
        private Mock<IResources> cost;

        [SetUp]
        public void SetUpStation()
        {
            this.unit = new Unit(3, "Goshkata");
            this.cost = new Mock<IResources>();
            this.cost.SetupGet(x => x.GoldCoins).Returns(0);
            this.cost.SetupGet(x => x.SilverCoins).Returns(0);
            this.cost.SetupGet(x => x.BronzeCoins).Returns(0);
        }

        [TestCase]
        public void Pay_shouldThrowNullReferenceException_WhenNullResource()
        {
            Assert.Throws<NullReferenceException>(() => this.unit.Pay(null));
        }


        [TestCase]
        public void Pay_shouldDecreaseOwnerAmountOfResourcesByTheAmountOfTheCost()
        {
            var resource = this.unit.Pay(this.cost.Object);

            // 0 - 0 = 0
            cost.VerifyAll();
            Assert.AreEqual(this.unit.Resources.GoldCoins, 0);
            Assert.AreEqual(this.unit.Resources.SilverCoins, 0);
            Assert.AreEqual(this.unit.Resources.BronzeCoins, 0);
        }

        // Roll
        [TestCase]
        public void Pay_shouldRollUintOwnersAmount_WhenOwnerHasLessThenNeeded()
        {
            var costWithResourceBiggerThanZero = new Mock<IResources>();
            costWithResourceBiggerThanZero.SetupGet(x => x.GoldCoins).Returns(1);
            costWithResourceBiggerThanZero.SetupGet(x => x.SilverCoins).Returns(1);
            costWithResourceBiggerThanZero.SetupGet(x => x.BronzeCoins).Returns(1);

            var resource = this.unit.Pay(costWithResourceBiggerThanZero.Object);
            //this is not OK - should have a check if the number is < 0

            Assert.AreEqual(this.unit.Resources.GoldCoins, 4294967295);
            Assert.AreEqual(this.unit.Resources.SilverCoins, 4294967295);
            Assert.AreEqual(this.unit.Resources.BronzeCoins, 4294967295);
        }

        [TestCase]
        public void Pay_shouldReturnResourceWithTheAmountOfResourcesInTheCostObject()
        {
            var resource = this.unit.Pay(this.cost.Object);

            cost.VerifyAll();
            Assert.AreEqual(resource.GetType().Name, typeof(Resources).Name);
            Assert.AreEqual(resource.GoldCoins, 0);
            Assert.AreEqual(resource.SilverCoins, 0);
            Assert.AreEqual(resource.BronzeCoins, 0);
        }
    }
}