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

            var exercisesServiceMock = new Mock<IExercisesServices>();
            exercisesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Exercise { Content = ExerciseContent, Category = new Category { Name = "asda" } });

            const string categoryName = "categoryname";
            var newCategory = new Category()
            {
                Name = categoryName
            };
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(newCategory);

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<ExerciseFullViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(ExerciseContent, viewModel.Content);
                    }).AndNoModelErrors();
        }

        [Test]
        public void DetailsWithNoValuesShouldRedirect()
        {
            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(0))
                .ShouldRenderView("Index")
                .WithModel<ExerciseLinkModel>();
        }

        [Test]
        public void MyExercisesShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.MyExercises())
                .ShouldRenderView("MyExercises")
                .WithModel<ExerciseLinkModel>().AndNoModelErrors();
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
                .ShouldRenderView("MyExercises")
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
                .ShouldRedirectTo("Index");
        }

        [Test]
        public void EditExerciseShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.EditExercise(1))
                .ShouldRenderView("EditExercise")
                .WithModel<ExerciseEditViewModel>().AndNoModelErrors();
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
                .ShouldRedirectTo("Index");
        }

        [Test]
        public void DeleteShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ExercisesController).Assembly);

            var exercisesServiceMock = new Mock<IExercisesServices>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new ExercisesController(exercisesServiceMock.Object, categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Delete(1))
                .ShouldRenderView("MyExercises")
                .WithModel<ExerciseEditViewModel>().AndNoModelErrors();
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
                .ShouldRedirectTo("Index");
        }
    }
}
