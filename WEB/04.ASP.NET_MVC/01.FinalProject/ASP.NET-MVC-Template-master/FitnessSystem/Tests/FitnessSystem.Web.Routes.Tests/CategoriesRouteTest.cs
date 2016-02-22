namespace FitnessSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using ViewModels.Categories;

    [TestFixture]
    public class CategoriesRouteTest
    {
        [Test]
        public void TestRouteIndex()
        {
            const string Url = "/Categories";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<CategoriesController>(c => c.Index());
        }

        [Test]
        public void TestRouteAbout()
        {
            const string Url = "/Categories/CreateNew";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<CategoriesController>(c => c.CreateNew());
        }

        [Test]
        public void TestRouteCreate()
        {
            var category = new CategorySimpleViewModel() { };
            const string Url = "/Categories/Create";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<CategoriesController>(c => c.Create(category));
        }

        [Test]
        public void TestRouteDetails()
        {
            const string Url = "/Categories/Details/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<CategoriesController>(c => c.Details(1));
        }

        [Test]
        public void TestRouteDetailsWithNoValue()
        {
            const string Url = "/Categories/Details/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<CategoriesController>(c => c.Index());
        }
    }
}
