namespace Testove
{
    using System.Web.Routing;
    using NUnit.Framework;

    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestRouteIndex()
        {
            const string Url = "/Home/Index";
            var routeCollection = new RouteCollection();
            var a = 5;
            Assert.AreEqual(a, 5);
        }
        
    }
}
