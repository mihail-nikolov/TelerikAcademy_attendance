namespace FitnessSystem.Services.Data
{
    using FitnessSystem.Data.Models;

    public interface IVotesServices
    {
        void AddOrUpdate(string authorId, int points, int exerciseId);

        int PointsToAdd(Vote vote, int givenPoints);
    }
}
