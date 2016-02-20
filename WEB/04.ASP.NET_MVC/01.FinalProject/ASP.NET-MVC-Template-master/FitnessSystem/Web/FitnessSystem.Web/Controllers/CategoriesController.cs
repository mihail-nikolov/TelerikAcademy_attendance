namespace FitnessSystem.Web.Controllers
{
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

        // TODO paging
        public ActionResult Index()
        {
            var categories = this.categories.GetAllVisible().To<CategoryWithExercisesViewModel>().ToList();
            return this.View(categories);
        }

        public ActionResult CreateNew()
        {
            return this.PartialView("_CreateCategoryPartial");
        }

        // TODO fix mappings
        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = this.categories.GetAllVisible().To<CategoryWithExercisesViewModel>().FirstOrDefault(c => c.Id == id);
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

            var category = new Category()
            {
                Name = newCategory.Name,
                IsVisible = false
            };
            this.categories.Create(category);
            string message = string.Format("Category with name {0} added, it will become visible when the Admin approves it", category.Name);
            this.TempData["notification"] = message;
            return this.RedirectToAction("Index");
        }
    }
}
