namespace ConsoleWebServer.Tests
{
    using NUnit.Framework;
    using Framework;

    [TestFixture]
    class ActionDescriptorTests
    {
        [Test]
        public void Constructor_ShouldSetTheDefaultValuesCorrectly()
        {
            var uri = "";
            var actionDescriptor = new ActionDescriptor(uri);
            Assert.AreEqual(actionDescriptor.ControllerName, "Home");
            Assert.AreEqual(actionDescriptor.ActionName, "Index");
            Assert.AreEqual(actionDescriptor.Parameter, "");
        }

        [Test]
        public void Constructor_ShouldSetNonDefaultValuesCorrectly()
        {

        }
    }
}
