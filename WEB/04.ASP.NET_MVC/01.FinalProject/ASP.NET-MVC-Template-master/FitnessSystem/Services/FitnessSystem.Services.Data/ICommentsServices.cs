namespace FitnessSystem.Services.Data
{
    using System.Linq;
    using FitnessSystem.Data.Models;

    public interface ICommentsServices
    {
        IQueryable<Comment> GetAll();

        void Create(Comment newComment);
    }
}
