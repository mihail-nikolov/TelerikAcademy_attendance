namespace FitnessSystem.Web.Controllers
{
    using System.Web.Mvc;
    using FitnessSystem.Services.Data;
    using Microsoft.AspNet.Identity;

    //[Authorize]
    //public class VotesController : BaseController
    //{
    //    private readonly IVotesServices votes;
    //    private readonly IExercisesServices exercises;

    //    public VotesController(IVotesServices votes, IExercisesServices exercises)
    //    {
    //        this.votes = votes;
    //        this.exercises = exercises;
    //    }

    //    [HttpPost]
    //    public ActionResult Vote(int exId, int points)
    //    {
    //        var userId = this.User.Identity.GetUserId();
    //        if (points > 1)
    //        {
    //            points = 1;
    //        }

    //        if (points < -1)
    //        {
    //            points = -1;
    //        }

    //        this.votes.AddOrUpdate(userId, points, exId);
    //        int exerciseVotes = this.exercises.GetVotesById(exId);

    //        return this.Json(new { Count = exerciseVotes });
    //    }
    //}
}