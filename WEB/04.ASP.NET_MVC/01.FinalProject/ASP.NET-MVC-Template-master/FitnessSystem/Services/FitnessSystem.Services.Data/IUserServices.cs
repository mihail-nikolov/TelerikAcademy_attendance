namespace FitnessSystem.Services.Data
{
    using System.Linq;
    using FitnessSystem.Data.Models;

    public interface IUserServices
    {
        void Delete(string id);

        IQueryable<ApplicationUser> GetAll();
    }
}
