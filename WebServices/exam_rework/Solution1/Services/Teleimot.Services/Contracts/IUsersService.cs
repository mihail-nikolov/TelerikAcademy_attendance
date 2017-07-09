namespace Teleimot.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetByUserName(string username);

        // not needed
        //IQueryable GetById(string userId);
    }
}
