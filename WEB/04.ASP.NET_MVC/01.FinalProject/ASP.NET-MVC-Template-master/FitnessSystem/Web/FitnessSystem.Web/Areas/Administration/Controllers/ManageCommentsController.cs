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
    public class ManageCommentsController : Controller
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
            return View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Comment> comments = db.Comments;
            DataSourceResult result = comments.ToDataSourceResult(request, c => new ManageCommentsViewModel 
            {
                Id = c.Id,
                Exercise = c.Exercise,
                Content = c.Content,
                Author = c.Author
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, ManageCommentsViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Id = comment.Id,
                    Exercise = comment.Exercise,
                    Content = comment.Content,
                    Author = comment.Author
                };

                db.Comments.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, ManageCommentsViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Id = comment.Id,
                    Exercise = comment.Exercise,
                    Content = comment.Content,
                    Author = comment.Author
                };

                db.Comments.Attach(entity);
                db.Comments.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
