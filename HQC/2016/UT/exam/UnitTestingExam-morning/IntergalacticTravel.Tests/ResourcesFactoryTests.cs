namespace IntergalacticTravel.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    class ResourcesFactoryTests
    {
        private ResourcesFactory resourcesFactory;

        [SetUp]
        public void SetUpFactory()
        {
            this.resourcesFactory = new ResourcesFactory();
        }
//===============================================================================================================
        [TestCase]
        public void GetResources_shouldThrowOverflowException_WhenGoldBiggerThanUintMaxValue()
        {
            Assert.Throws<OverflowException>(() => this.resourcesFactory.GetResources("create resources bronze(40) silver(30) gold(97853252356623523532)"));
        }

        [TestCase]
        public void GetResources_shouldThrowOverflowException_WhenSilverBiggerThanUintMaxValue()
        {
            Assert.Throws<OverflowException>(() => this.resourcesFactory.GetResources("create resources bronze(40) silver(555555555555555555555555555555555) gold(10)"));
        }
//===============================================================================================================

        [TestCase]
        public void GetResources_shouldThrowInvalidOperationException_WhenMoreIntervals()
        {
            Assert.Throws<InvalidOperationException>(() => this.resourcesFactory.GetResources("create  resources bronze(40) silver(30) gold(20)"));
        }

        [TestCase]
        public void GetResources_shouldThrowOverflowException_WhenIvanlidBrackets()
        {
            Assert.Throws<InvalidOperationException>(() => this.resourcesFactory.GetResources("create resources bronze[40] silver(20) gold(10)"));
        }
//===============================================================================================================

        [TestCase("gold(20) silver(30) bronze(40)")]
        [TestCase("gold(20) bronze(40) silver(30)")]
        [TestCase("silver(30) bronze(40) gold(20)")]
        [TestCase("silver(30) gold(20) bronze(40)")]
        [TestCase("bronze(40) gold(20) silver(30)")]
        [TestCase("bronze(40) silver(30) gold(20)")]
        public void GetResources_ShouldCreateValidResourceWithValidProperties_WhenParametersPlacesChanged(string resourceParams)
        {
            string command = "create resources ";

            string fullCommand = command + resourceParams;
            var resource = this.resourcesFactory.GetResources(fullCommand);

            Assert.AreEqual(resource.GetType().Name, typeof(Resources).Name);
            Assert.AreEqual(resource.GoldCoins, 20);
            Assert.AreEqual(resource.SilverCoins, 30);
            Assert.AreEqual(resource.BronzeCoins, 40);
        }
    }
}
