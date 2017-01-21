namespace FitnessSystem.Web.Controllers.Tests
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data;
    using TestStack.FluentMVCTesting;
    using ViewModels.Exercises;

    [TestFixture]

    public class ExercisesControllerTests
    {
        [Test]
        public void DetailsShouldWorkCorrecrly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);
            const string ExerciseContent = "SomeContent";

            const string categoryName = "categoryname";
            var exercisesServiceMock = new Mock<IExercisesServices>();
            exercisesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Exercise { Content = ExerciseContent, Category = new Category { Name = categoryName } });

            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<ExerciseAndNewCommentViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(ExerciseContent, viewModel.Exercise.Content);
                        Assert.AreEqual(categoryName, viewModel.Exercise.Category);
                    }).AndNoModelErrors();
        }

        [Test]
        public void DetailsWithNoValuesShouldRedirect()
        {
            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            exercisesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Exercise { Content = "new  exercise", Category = new Category { Name = "asda" } });
            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(0))
                .ShouldRedirectTo("~/Exercises");
        }

        [Test]
        public void AddNewCommentShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.AddNewComment(1))
                .ShouldRenderPartialView("_AddComment")
                .WithModel<ExerciseAndNewCommentViewModel>().AndNoModelErrors();
        }

        [Test]
        public void AddNewCommentWithNoValuesShouldRedirect()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.AddNewComment(0))
                .ShouldRedirectTo("~/Exercises");
        }

        [Test]
        public void EditExerciseWithNoValuesShouldRedirect()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.EditExercise(0))
                .ShouldRedirectTo("~/Exercises");
        }

        [Test]
        public void DeleteWithNoValuesShouldRedirect()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Delete(0))
                .ShouldRedirectTo("~/Exercises");
        }
    }
}
