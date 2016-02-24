namespace FitnessSystem.Services.Data
{
    using System.Linq;
    using FitnessSystem.Data.Models;
    using Microsoft.AspNet.Identity;

    public class UserServices : IUserServices
    {
        private readonly UserManager<ApplicationUser> manager;

        public UserServices(UserManager<ApplicationUser> manager)
        {
            this.manager = manager;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.manager.Users.Where(u => u.IsDeleted == false).AsQueryable();
        }

        public void Delete(string id)
        {
            var user = this.manager.Users.FirstOrDefault(u => u.Id == id);
            user.IsDeleted = true;
            this.manager.Update(user);
        }
    }
}
