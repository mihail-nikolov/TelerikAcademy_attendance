namespace Teleimot.Services
{
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using Teleimot.Data.Models;
    using Teleimot.Services.Contracts;

    public class UsersService : IUsersService
    {
        // could be done with repository pattern, too
        //private readonly UserManager<User> userManager;
        private readonly ITeleimotDbContext dbContext;

        //public UsersService(UserManager<User> userManager)
        //{
        //    this.userManager = userManager;
        //}

        public UsersService(ITeleimotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public UserManager<User> Manager { get { return this.userManager; } set { this.userManager = value; } }

        //public IQueryable GetById(string userId)
        //{
        //    return this.dbContext.Users.Where
        //}

        public IQueryable<User> GetByUserName(string username)
        {
            var users = this.dbContext.Users;
            return this.dbContext.Users.Where(u => u.UserName == username).AsQueryable();
        }
    }
}
