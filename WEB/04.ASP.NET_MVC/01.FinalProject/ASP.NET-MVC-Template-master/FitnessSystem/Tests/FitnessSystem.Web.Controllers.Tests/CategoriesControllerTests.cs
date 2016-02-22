namespace FitnessSystem.Web.Controllers.Tests
{
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data;
    using TestStack.FluentMVCTesting;
    using ViewModels.Categories;

    [TestFixture]

    public class CategoriesControllerTests
    {
        [Test]
        public void DetailsShouldWorkCorrecrly()
        {
            const string categoryName = "categoryname";
            var newCategory = new Category()
            {
                Name = categoryName
            };
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(newCategory);

            var controller = new CategoriesController(categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<CategoryWithExercisesViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(categoryName, viewModel.Name);
                    }).AndNoModelErrors();
        }

        public void DetailsWithNoValueShouldWorkCorrecrly()
        {
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new CategoriesController(categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(0))
                .ShouldRedirectTo("/Categories");
        }

        [Test]
        public void CreateNewShouldWorkCorrectly()
        {
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new CategoriesController(categoriesServiceMock.Object);
            controller.WithCallTo(x => x.CreateNew())
                .ShouldRenderView("_CreateCategoryPartial")
                .WithModel<CategorySimpleViewModel>().AndNoModelErrors();
        }
    }
}
