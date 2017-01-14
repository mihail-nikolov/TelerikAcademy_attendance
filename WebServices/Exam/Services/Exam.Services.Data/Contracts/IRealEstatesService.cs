namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRealEstatesService
    {
        List<RealEstate> GetPublicRealEstates(int skip = 0, int take = 1);

        RealEstate CreateRealEstate(string title, string description, string address, string contact, int constructionYear, int sellingPrice, int RentingPrice, RealEstateType type, string userId);

        IQueryable<RealEstate> GetRealEstateDetails(int id);
    }
}
