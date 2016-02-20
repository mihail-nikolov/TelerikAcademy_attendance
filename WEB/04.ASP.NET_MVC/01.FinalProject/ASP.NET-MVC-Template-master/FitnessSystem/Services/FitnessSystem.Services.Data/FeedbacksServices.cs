namespace FitnessSystem.Services.Data
{
    using System.Linq;
    using FitnessSystem.Data.Common;
    using FitnessSystem.Data.Models;

    public class FeedbacksServices : IFeedbacksServices
    {
        private readonly IDbRepository<Feedback> feedbacks;

        public FeedbacksServices(IDbRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public IQueryable<Feedback> GetAll()
        {
            return this.feedbacks.All().OrderByDescending(f => f.CreatedOn);
        }

        public void Create(Feedback newFeedback)
        {
            this.feedbacks.Add(newFeedback);
            this.feedbacks.Save();
        }
    }
}
