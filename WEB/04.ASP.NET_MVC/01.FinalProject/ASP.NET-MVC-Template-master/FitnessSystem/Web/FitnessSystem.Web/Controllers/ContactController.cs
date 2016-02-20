namespace FitnessSystem.Web.Controllers
{
    using Data.Models;
    using Services.Data;
    using System.Web.Mvc;
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
        public ActionResult Feedback(FeedbackCreateViewModel newFeedBack)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            var feedback = new Feedback()
            {
                Title = newFeedBack.Title,
                Content = newFeedBack.Content
            };
            this.feedbacks.Create(feedback);

            this.TempData["notification"] = "Your feedback is send and will be checked by the Admin";
            return this.RedirectToAction("Index");
        }
    }
}