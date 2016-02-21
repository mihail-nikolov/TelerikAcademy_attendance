namespace FitnessSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Categories;

    [Authorize]
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var categories = this.Cache.Get(
                "Categories_Main_Page",
                () => this.categories.GetAllVisible().To<CategoriesPageViewModel>().ToList(),
                10 * 60);
            return this.View(categories);
        }

        public ActionResult CreateNew()
        {
            return this.PartialView("_CreateCategoryPartial");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = this.Mapper.Map<CategoryWithExercisesViewModel>(this.categories.GetById(id));
            return this.View(category);
        }

        [HttpPost]
        public ActionResult Create(CategorySimpleViewModel newCategory)
        {
            if (!this.ModelState.IsValid || this.categories.IfExists(newCategory.Name))
            {
                this.TempData["notification"] = "There is already existing category with this name (it also could not be visible yet)";
                return this.RedirectToAction("Index");
            }

            var category = this.Mapper.Map<Category>(newCategory);
            category.IsVisible = false;
            this.categories.Create(category);

            string message = string.Format("Category with name {0} added, it will become visible when the Admin approves it", category.Name);
            this.TempData["notification"] = message;
            return this.RedirectToAction("Index");
        }
    }
}
