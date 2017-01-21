namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Feedbacks;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class FeedbacksCheckController : BaseController
    {
        private readonly IFeedbacksServices feedbacks;

        public FeedbacksCheckController(IFeedbacksServices feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Feedbacks_Read([DataSourceRequest]DataSourceRequest request)
        {
            var feedbacks = this.feedbacks.GetAll().To<FeedbacksCheckViewModel>().ToList();
            DataSourceResult result = feedbacks.ToDataSourceResult(request);
            return this.Json(result);
        }
    }
}
