namespace Teleimot.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Common.Contracts;
    using Data.Models;
    using Contracts;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public int Create(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.Save();

            return comment.Id;
        }

        public IEnumerable<Comment> GetByRealEstate(int take, int skip, int realEstateId)
        {
            return this.comments
                       .All()
                       .Where(c => c.RealEstateId == realEstateId)
                       .OrderBy(c => c.CreatedOn)
                       .Skip(skip)
                       .Take(take)
                       .ToList();
        }

        public IEnumerable<Comment> GetByUser(int take, int skip, string userName)
        {
            return this.comments
                       .All()
                       .Where(c => c.User.UserName == userName)
                       .OrderBy(c => c.CreatedOn)
                       .Skip(skip)
                       .Take(take)
                       .ToList();
        }

        public IEnumerable<Comment> GetDetailsById(int id)
        {
            return this.comments
                        .All()
                        .Where(c => c.Id == id);
        }
    }
}
