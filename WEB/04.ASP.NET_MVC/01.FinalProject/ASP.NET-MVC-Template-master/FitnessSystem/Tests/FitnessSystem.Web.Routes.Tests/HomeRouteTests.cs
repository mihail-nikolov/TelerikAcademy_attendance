namespace FitnessSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class HomeRouteTests
    {
        [Test]
        public void TestRouteIndex()
        {
            const string Url = "/Home/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestRouteAbout()
        {
            const string Url = "/Home/About";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.About());
        }
    }
}
