namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using FitnessSystem.Data.Models;
    using FitnessSystem.Web.ViewModels.Categories;
    using FitnessSystem.Services.Data;
    using Web.Controllers;
    using Infrastructure.Mapping;
    public class ManageCategoriesController : BaseController
    {
        private readonly ICategoriesService categories;

        public ManageCategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.categories.GetAll().To<ManageCategoriesSimpleViewModel>().ToList();
            DataSourceResult result = categories.ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, ManageCategoriesSimpleViewModel category)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = category.Name,
                    IsVisible = category.IsVisible
                };

                this.categories.Create(entity);
                category.Id = entity.Id;
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, ManageCategoriesSimpleViewModel category)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    IsVisible = category.IsVisible
                };

                this.categories.Update(entity);
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, ManageCategoriesSimpleViewModel category)
        {
            if (this.ModelState.IsValid)
            {
                this.categories.Delete(category.Id);
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

    }
}
