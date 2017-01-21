namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using Web.Administration.ViewModels;
    using Web.Administration.ViewModels.Comments;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageCommentsController : BaseController
    {
        private readonly ICommentsServices comments;

        public ManageCommentsController(ICommentsServices comments)
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            var comments = this.comments.GetAll().To<ManageCommentsViewModel>().ToList();
            DataSourceResult result = comments.ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, ManageCommentsViewModel comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Comment()
                {
                    Id = comment.Id,
                    Content = comment.Content
                };
                this.comments.Update(entity);
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, ManageCommentsViewModel comment)
        {
            if (this.ModelState.IsValid)
            {
                this.comments.Delete(comment.Id);
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
