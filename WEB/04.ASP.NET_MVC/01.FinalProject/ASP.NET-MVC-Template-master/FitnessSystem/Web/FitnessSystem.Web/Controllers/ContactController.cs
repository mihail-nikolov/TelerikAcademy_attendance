namespace FitnessSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using ViewModels.Feedbacks;

    public class ContactController : BaseController
    {
        private readonly IFeedbacksServices feedbacks;

        public ContactController(IFeedbacksServices feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feedback(FeedbackCreateViewModel newFeedBack)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            var feedback = this.Mapper.Map<Feedback>(newFeedBack);
            this.feedbacks.Create(feedback);

            this.TempData["notification"] = "Your feedback is send and will be checked by the Admin";
            return this.RedirectToAction("Index");
        }
    }
}
