namespace FitnessSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using FitnessSystem.Web.Areas.Administration.ViewModels.Feedbacks;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using Web.Controllers;

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
