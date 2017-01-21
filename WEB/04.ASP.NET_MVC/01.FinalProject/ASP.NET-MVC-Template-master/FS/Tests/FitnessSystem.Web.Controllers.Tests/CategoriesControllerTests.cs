namespace FitnessSystem.Web.Controllers.Tests
{
    using Data.Models;
    using Infrastructure.Mapping;
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
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(CategoriesController).Assembly);

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

        [Test]
        public void DetailsWithNoValueShouldWorkCorrecrly()
        {
            var categoriesServiceMock = new Mock<ICategoriesService>();

            var controller = new CategoriesController(categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Details(0))
                .ShouldRedirectTo("~/Categories");
        }

        [Test]
        public void CreateCategoryThatExistsShouldRedirect()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(CategoriesController).Assembly);

            const string categoryName = "categoryname";
            var newCategory = new CategorySimpleViewModel()
            {
                Name = categoryName
            };
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.IfExists("categoryname"))
                .Returns(true);

            var controller = new CategoriesController(categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Create(newCategory))
                .ShouldRedirectTo("~/Categories/Index");
        }

        [Test]
        public void CreateShouldWorkCorrecrly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(CategoriesController).Assembly);

            const string categoryName = "categoryname";
            var newCategory = new CategorySimpleViewModel()
            {
                Name = categoryName
            };
            var newCategoryViewModel = new Category()
            {
                Name = categoryName
            };
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.IfExists("categoryname"))
                .Returns(false);
            categoriesServiceMock.Setup(x => x.Create(newCategoryViewModel));

            var controller = new CategoriesController(categoriesServiceMock.Object);
            controller.WithCallTo(x => x.Create(newCategory))
                .ShouldRedirectTo("~/Categories/Index");
        }
    }
}
