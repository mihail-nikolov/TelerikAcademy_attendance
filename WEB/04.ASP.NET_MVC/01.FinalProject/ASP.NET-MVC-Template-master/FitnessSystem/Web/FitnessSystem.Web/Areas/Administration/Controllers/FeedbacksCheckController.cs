using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using FitnessSystem.Data.Models;
using FitnessSystem.Data;
using FitnessSystem.Web.Areas.Administration.ViewModels.Feedbacks;

namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    public class FeedbacksCheckController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Feedbacks_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Feedback> feedbacks = db.Feedbacks;
            DataSourceResult result = feedbacks.ToDataSourceResult(request, c => new FeedbacksCheckViewModel
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                CreatedOn = c.CreatedOn
            });

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
