namespace FitnessSystem.Services.Data
{
    using System.Linq;
    using FitnessSystem.Data.Common;
    using FitnessSystem.Data.Models;

    public class CommentsServices : ICommentsServices
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsServices(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Create(Comment newComment)
        {
            var comment = new Comment()
            {
                AuthorId = newComment.AuthorId,
                ExerciseId = newComment.ExerciseId,
                Content = newComment.Content
            };
            this.comments.Add(comment);
            this.comments.Save();
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All().OrderByDescending(c => c.CreatedOn);
        }
    }
}
