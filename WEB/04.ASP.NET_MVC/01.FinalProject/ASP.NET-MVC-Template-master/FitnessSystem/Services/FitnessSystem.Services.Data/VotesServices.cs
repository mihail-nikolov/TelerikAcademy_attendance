namespace FitnessSystem.Services.Data
{
    using System.Linq;

    using FitnessSystem.Data.Common;
    using FitnessSystem.Data.Models;

    public class VotesServices : IVotesServices
    {
    //    private readonly IDbRepository<Vote> votes;

    //    public VotesServices(IDbRepository<Vote> votes)
    //    {
    //        this.votes = votes;
    //    }

    //    public void AddOrUpdate(string authorId, int points, int exerciseId)
    //    {
    //        var vote = this.votes.All().FirstOrDefault(x => x.AuthorId == authorId && x.ExerciseId == exerciseId);
    //        if (vote == null)
    //        {
    //            vote = new Vote()
    //            {
    //                AuthorId = authorId,
    //                ExerciseId = exerciseId,
    //                Points = points
    //            };

    //            this.votes.Add(vote);
    //        }
    //        else
    //        {
    //            vote.Points = points;
    //        }
    //    }

    //    public IQueryable<Vote> GetAll()
    //    {
    //        return this.votes.All();
    //    }
    }
}
