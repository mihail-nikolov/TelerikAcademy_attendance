namespace Teleimot.Services.Contracts
{
    using System.Collections.Generic;
    using Data.Models;

    public interface ICommentsService
    {
        int Create(Comment comment);

        IEnumerable<Comment> GetDetailsById(int id);

        IEnumerable<Comment> GetByUser(int take, int skip, string userName);

        IEnumerable<Comment> GetByRealEstate(int take, int skip, int realEstateId);
    }
}
