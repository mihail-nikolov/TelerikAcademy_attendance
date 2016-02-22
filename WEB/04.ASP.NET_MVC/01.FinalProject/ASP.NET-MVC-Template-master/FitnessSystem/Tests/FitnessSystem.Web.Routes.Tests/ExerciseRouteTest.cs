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
            const string Url = "/Categories/Details/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Index());
        }

        [Test]
        public void TestRouteCreate()
        {
            var exercise = new ExerciseEditViewModel() { };
            const string Url = "/Exercises/Create";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Create(exercise));
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
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.AddNewComment(0));
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
            const string Url = "/Exercises/EditExercise";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.EditExercise(0));
        }

        [Test]
        public void TestRouteEdit()
        {
            var newExercise = new ExerciseEditViewModel() { };
            const string Url = "/Exercises/Edit";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Edit(newExercise));
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
            routeCollection.ShouldMap(Url).To<ExercisesController>(c => c.Delete(0));
        }
    }
}
