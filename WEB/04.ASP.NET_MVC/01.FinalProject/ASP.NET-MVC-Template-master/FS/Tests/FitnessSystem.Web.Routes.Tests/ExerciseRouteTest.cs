namespace FitnessSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using ViewModels.Exercises;

    [TestFixture]

    public class ExerciseRouteTest
    {
        [Test]
        public void TestRouteIndex()
        {
            const string Url = "/Exercises/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Index());
        }

        [Test]
        public void TestRouteDetails()
        {
            const string Url = "/Exercises/Details/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Details(1));
        }

        [Test]
        public void TestRouteDetailsWithNoValue()
        {
            const string Url = "/Exercises/Details/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).ToNonIgnoredRoute();
            routeCollection.ShouldMap(Url).WithFormUrlBody("id=0");
        }

        [Test]
        public void TestRouteCreateNew()
        {
            const string Url = "/Exercises/CreateNew";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.CreateNew());
        }

        [Test]
        public void TestRouteAbout()
        {
            const string Url = "/Exercises/MyExercises";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.MyExercises());
        }

        [Test]
        public void TestRouteAddNewComment()
        {
            const string Url = "/Exercises/AddNewComment/2";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.AddNewComment(2));
        }

        [Test]
        public void TestRouteAddNewCommentWithNoValue()
        {
            const string Url = "/Exercises/AddNewComment/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).ToNonIgnoredRoute();
            routeCollection.ShouldMap(Url).WithFormUrlBody("id=0");
        }

        [Test]
        public void TestRouteEditExercise()
        {
            const string Url = "/Exercises/EditExercise/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.EditExercise(1));
        }

        [Test]
        public void TestRouteEditExerciseWithNoValue()
        {
            const string url = "/Exercises/EditExercise";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url).ToNonIgnoredRoute();
            routeCollection.ShouldMap(url).WithFormUrlBody("id=0");
        }

        [Test]
        public void TestRouteDelete()
        {
            var newExercise = new ExerciseEditViewModel() { };
            const string Url = "/Exercises/Delete/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Delete(1));
        }

        [Test]
        public void TestRouteDeleteWithNoValue()
        {
            var newExercise = new ExerciseEditViewModel() { };
            const string Url = "/Exercises/Delete";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).ToNonIgnoredRoute();
            routeCollection.ShouldMap(Url).WithFormUrlBody("id=0");
        }
    }
}
