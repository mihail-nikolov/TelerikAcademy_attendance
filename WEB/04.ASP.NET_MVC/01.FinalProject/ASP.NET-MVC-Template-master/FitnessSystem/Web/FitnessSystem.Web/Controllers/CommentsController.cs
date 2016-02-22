namespace FitnessSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;

    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ICommentsServices comments;

        public CommentsController(ICommentsServices comments)
        {
            this.comments = comments;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(string content, int exId = 0)
        {
            if (string.IsNullOrEmpty(content) || exId == 0)
            {
                this.TempData["notification"] = "Cannot send an empty comment";
                return this.Redirect("/Exercises");
            }

            var userId = this.User.Identity.GetUserId();
            var userName = this.User.Identity.GetUserName();
            var comment = new Comment()
            {
                AuthorId = userId,
                Content = content,
                ExerciseId = exId
            };
            this.comments.Create(comment);

            return this.Json(new { Content = content, author = userName });
        }
    }
}
