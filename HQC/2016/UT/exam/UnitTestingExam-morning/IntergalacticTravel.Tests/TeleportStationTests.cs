namespace IntergalacticTravel.Tests
{
    using Contracts;
    using Exceptions;
    using Mocked;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    [TestFixture]
    class TeleportStationTests
    {
        private ExtendedTeleportStation teleportStation;
        private Mock<IBusinessOwner> owner;
        private Mock<IPath> path;
        private List<IPath> paths;
        private Mock<ILocation> location;

        [SetUp]
        public void SetUpStation()
        {
            this.owner = new Mock<IBusinessOwner>();
            this.path = new Mock<IPath>();
            this.location = new Mock<ILocation>();
            this.paths = new List<IPath>();
            this.paths.Add(this.path.Object);
        }

//===============================================================================================================
        [TestCase]
        public void Constructor_ShouldSetUpAllOfTheProvidedFields()
        {
            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);

            Assert.AreSame(this.teleportStation.Location, this.location.Object);
            Assert.AreSame(this.teleportStation.GalacticMap, this.paths);
            Assert.AreSame(this.teleportStation.Owner, this.owner.Object);
        }

//===============================================================================================================
        [TestCase]
        public void TeleportUnitShouldThrowArgumentNullExceptionWithMessageUnitToTeleport_WhenUnitToTeleportNull()
        {
            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            Assert.That(() => this.teleportStation.TeleportUnit(null, this.location.Object), Throws.ArgumentNullException.With.Message.Contains("unitToTeleport"));
        }

        [TestCase]
        public void TeleportUnitShouldThrowArgumentNullExceptionWithMessageDestination_DestinationNull()
        {
            var unit = new Mock<IUnit>();
            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            Assert.That(() => this.teleportStation.TeleportUnit(unit.Object, null), Throws.ArgumentNullException.With.Message.Contains("destination"));
        }

        [TestCase]
        public void TeleportUnit_ShouldThrowTeleportOutOfRangeExceptionWithMessageUnitToTeleportCurrentLocation_WhenTryingToUseTeleportFromDistantLocation()
        {
            this.location.SetupGet(x => x.Planet.Name).Returns("Earth");
            this.location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");

            var unitLocation = new Mock<ILocation>();
            unitLocation.SetupGet(x => x.Planet.Name).Returns("Mars");
            unitLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy2");

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);

            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            var ex = Assert.Throws<TeleportOutOfRangeException>(() => this.teleportStation.TeleportUnit(unit.Object, this.location.Object));

            bool contains = ex.Message.Contains("unitToTeleport.CurrentLocation");
            Assert.IsTrue(contains);
        }
//===============================================================================================================
        [TestCase]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionWithMessageGalaxy_WhenNonExsistingGalaxy()
        {
            this.location.SetupGet(x => x.Planet.Name).Returns("Earth");
            this.location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");

            var targetLocation = new Mock<ILocation>();
            targetLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            targetLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("PodZemyata");

            var unitLocation = new Mock<ILocation>();
            unitLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            unitLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);

            var unitOnThePath = new Mock<IUnit>();
            unitOnThePath.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            var units = new List<IUnit>();
            units.Add(unitOnThePath.Object);

            this.path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Galaxy1");
            this.path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            this.path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(units);

            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            var ex = Assert.Throws<LocationNotFoundException>(() => this.teleportStation.TeleportUnit(unit.Object, targetLocation.Object));

            bool contains = ex.Message.Contains("Galaxy");
            Assert.IsTrue(contains);
        }

        [TestCase]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionWithMessagePlanet_WhenNonExsistingPlanet()
        {
            this.location.SetupGet(x => x.Planet.Name).Returns("Earth");
            this.location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");

            var targetLocation = new Mock<ILocation>();
            targetLocation.SetupGet(x => x.Planet.Name).Returns("PodZemyata");
            targetLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");

            var unitLocation = new Mock<ILocation>();
            unitLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            unitLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);

            var unitOnThePath = new Mock<IUnit>();
            unitOnThePath.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            var units = new List<IUnit>();
            units.Add(unitOnThePath.Object);

            this.path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Galaxy1");
            this.path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            this.path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(units);

            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            var ex = Assert.Throws<LocationNotFoundException>(() => this.teleportStation.TeleportUnit(unit.Object, targetLocation.Object));

            bool contains = ex.Message.Contains("Planet");
            Assert.IsTrue(contains);
        }
 //===============================================================================================================
        [TestCase]
        public void TeleportUnit_ShouldThrowInvalidTeleportationLocationExceptionWithMessage_UnitsWillOverlap_WhenTryingToTeleportToLocationAlreadyTaken()
        {
            this.location.SetupGet(x => x.Planet.Name).Returns("Earth");
            this.location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
            this.location.SetupGet(x => x.Coordinates.Longtitude).Returns(2);
            this.location.SetupGet(x => x.Coordinates.Latitude).Returns(3);

            var unitLocation = new Mock<ILocation>();
            unitLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            unitLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
            unitLocation.SetupGet(x => x.Coordinates.Longtitude).Returns(2);
            unitLocation.SetupGet(x => x.Coordinates.Latitude).Returns(3);

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);

            var unitOnThePath = new Mock<IUnit>();
            unitOnThePath.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            var units = new List<IUnit>();
            units.Add(unitOnThePath.Object);

            this.path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Galaxy1");
            this.path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            this.path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(units);

            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            var ex = Assert.Throws<InvalidTeleportationLocationException>(() => this.teleportStation.TeleportUnit(unit.Object, this.location.Object));

            bool contains = ex.Message.Contains("units will overlap");
            Assert.IsTrue(contains);
        }

        [TestCase]
        public void TeleportUnit_ShouldThrowInsufficientResourcesExceptionWithMessageContains_FreeLunch_WhenNoMoneyForTheLocation()
        {
            this.location.SetupGet(x => x.Planet.Name).Returns("Earth");
            this.location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
            this.location.SetupGet(x => x.Coordinates.Longtitude).Returns(2);
            this.location.SetupGet(x => x.Coordinates.Latitude).Returns(3);

            var unitLocation = new Mock<ILocation>();
            unitLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            unitLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
            unitLocation.SetupGet(x => x.Coordinates.Longtitude).Returns(2);
            unitLocation.SetupGet(x => x.Coordinates.Latitude).Returns(4);

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);

            var unitOnThePath = new Mock<IUnit>();
            unitOnThePath.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            var units = new List<IUnit>();
            units.Add(unitOnThePath.Object);

            this.path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Galaxy1");
            this.path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            this.path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(units);

            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            var ex = Assert.Throws<InsufficientResourcesException>(() => this.teleportStation.TeleportUnit(unit.Object, this.location.Object));

            bool contains = ex.Message.Contains("FREE LUNCH");
            Assert.IsTrue(contains);
        }
        //===============================================================================================================
        [TestCase]
        public void TeleportUnit_ShouldRequireAPayment_WhenValidatorsPassed()
        {
            this.location.SetupGet(x => x.Planet.Name).Returns("Earth");
            this.location.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
            this.location.SetupGet(x => x.Coordinates.Longtitude).Returns(2);
            this.location.SetupGet(x => x.Coordinates.Latitude).Returns(3);

            var unitLocation = new Mock<ILocation>();
            unitLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            unitLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
            unitLocation.SetupGet(x => x.Coordinates.Longtitude).Returns(2);
            unitLocation.SetupGet(x => x.Coordinates.Latitude).Returns(4);

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            unit.Setup(x => x.Resources.GoldCoins).Returns(100);
            unit.Setup(x => x.Resources.SilverCoins).Returns(200);
            unit.Setup(x => x.Resources.BronzeCoins).Returns(300);
            unit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(new Mock<IResources>().Object);

            var unitOnThePath = new Mock<IUnit>();
            unitOnThePath.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            var units = new List<IUnit>();
            units.Add(unitOnThePath.Object);

            this.path.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Galaxy1");
            this.path.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            this.path.SetupGet(x => x.TargetLocation.Planet.Units).Returns(units);
            this.path.SetupGet(x => x.Cost).Returns(new Mock<IResources>().Object);

            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);
            this.teleportStation.TeleportUnit(unit.Object, this.location.Object);

            unit.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
        }


        //===============================================================================================================
        [TestCase]
        public void PayProfits_ShouldReturnActualAmount_WhenSameOwneer()
        {
            this.teleportStation = new ExtendedTeleportStation(this.owner.Object, this.paths, this.location.Object);

            var payment = this.teleportStation.PayProfits(this.owner.Object);
            Assert.AreEqual(0, payment.GoldCoins);
            Assert.AreEqual(0, payment.SilverCoins);
            Assert.AreEqual(0, payment.BronzeCoins);
        }
    }
}