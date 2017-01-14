namespace Exam.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exam.Data.Models;
    using Exam.Services.Data.Contracts;
    using Exam.Data.Repositories;

    public class CommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment CreateComment(int realEstateID, string content, string userId)
        {
            var newComment = new Comment
            {
                RealEstateId = realEstateID,
                Content = content,
                UserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment;
        }

        public IQueryable<Comment> GetCommentDetails(int id)
        {
            return this.comments
               .All()
               .Where(g => g.Id == id);
        }

        public List<Comment> GetListedComments(int skip, int take)
        {
            var publicRealEstates = this.comments
                .All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take)
                .ToList();
            return publicRealEstates;
        }

        public List<Comment> GetListedCommentsByUserName(int skip, int take, string username)
        {
            var publicRealEstates = this.comments
                .All()
                .Where(c => c.User.UserName == username)
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take)
                .ToList();
            return publicRealEstates;
        }
    }
}
