using FitnessSystem.Services.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessSystem.Web.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly IExercisesServices exercises;
       // private readonly IExercisesServices exercises;

        public CommentsController( IExercisesServices exercises)
        {
           // this.votes = votes;
            this.exercises = exercises;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(int exId, string content)
        {
            if (content == string.Empty)
            {
                this.TempData["notification"] = "Cannot send an empty comment";
                return this.Redirect("/Exercises");
            }

            var userId = this.User.Identity.GetUserId();

            //this.comments.Add(userId, points, exId);

            return this.Json(new { Content = content });
        }
    }
}