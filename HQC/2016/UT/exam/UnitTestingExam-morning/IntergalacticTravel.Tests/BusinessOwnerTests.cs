namespace IntergalacticTravel.Tests
{
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    class BusinessOwnerTests
    {

        [TestCase]
        public void CollectProfits_ShouldIncreaseOwnerResourcesByResourcesGeneratedFromTheTeleportStations()
        {
            var resources = new Mock<IResources>();
            resources.SetupGet(x => x.GoldCoins).Returns(3);
            resources.SetupGet(x => x.SilverCoins).Returns(3);
            resources.SetupGet(x => x.BronzeCoins).Returns(3);

            var station = new Mock<ITeleportStation>();
            station.Setup(x => x.PayProfits(It.IsAny<BusinessOwner>())).Returns(resources.Object);

            var teleportStationsList = new List<ITeleportStation>();
            teleportStationsList.Add(station.Object);

            var owner = new BusinessOwner(3, "Goshkata", teleportStationsList);

            owner.CollectProfits();

            resources.VerifyAll();
            station.VerifyAll();
            Assert.AreEqual(owner.Resources.GoldCoins, 3);
            Assert.AreEqual(owner.Resources.SilverCoins, 3);
            Assert.AreEqual(owner.Resources.BronzeCoins, 3);
        }
    }
}
