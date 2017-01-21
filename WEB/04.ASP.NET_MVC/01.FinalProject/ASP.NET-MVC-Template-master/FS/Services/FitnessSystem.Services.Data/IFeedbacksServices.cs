namespace FitnessSystem.Services.Data
{
    using System.Linq;
    using FitnessSystem.Data.Models;

    public interface IFeedbacksServices
    {
        IQueryable<Feedback> GetAll();

        void Create(Feedback newFeedback);
    }
}
