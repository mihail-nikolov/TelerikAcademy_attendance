namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using Web.Administration.ViewModels;
    using Web.Controllers;
    using Web.ViewModels.Categories;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageExercisesController : BaseController
    {
        private readonly IExercisesServices exercises;
        private readonly ICategoriesService categories;

        public ManageExercisesController(IExercisesServices exercises, ICategoriesService categories)
        {
            this.exercises = exercises;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var categories = this.categories.GetAll().To<ManageCategoriesSimpleViewModel>().OrderBy(c => c.Name).ToList();
            this.ViewData["categories"] = categories;

            return this.View();
        }

        public ActionResult Exercises_Read([DataSourceRequest]DataSourceRequest request)
        {
            var exercises = this.exercises.GetAll().To<ManageExerciseViewModel>().ToList();
            DataSourceResult result = exercises.ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Exercises_Update([DataSourceRequest]DataSourceRequest request, ManageExerciseViewModel exercise)
        {
            var category = this.categories.GetAll().FirstOrDefault(c => c.Name == exercise.Category);
            if (this.ModelState.IsValid)
            {
                var entity = new Exercise()
                {
                    Id = exercise.Id,
                    CategoryId = category.Id
                };
                this.exercises.ChangeCategory(entity);
            }

            return this.Json(new[] { exercise }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Exercises_Destroy([DataSourceRequest]DataSourceRequest request, ManageExerciseViewModel exercise)
        {
            if (this.ModelState.IsValid)
            {
                this.exercises.Delete(exercise.Id);
            }

            return this.Json(new[] { exercise }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
