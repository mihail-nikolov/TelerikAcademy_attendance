namespace Teleimot.Services
{
    using Data.Common.Contracts;
    using Data.Models;
    using Contracts;

    public class RatingsService : IRatingsService
    {
        private readonly IDbRepository<Rating> ratings;

        public RatingsService(IDbRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public void Create(Rating rating)
        {
            this.ratings.Add(rating);
            this.ratings.Save();
        }
    }
}
