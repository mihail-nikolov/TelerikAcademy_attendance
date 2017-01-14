namespace Exam.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exam.Data.Models;
    using Exam.Services.Data.Contracts;
    using Exam.Data.Repositories;

    public class RealEstatesService : IRealEstatesService
    {
        private readonly IRepository<RealEstate> realEstates;

        public RealEstatesService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public RealEstate CreateRealEstate(string title,
               string description,
               string address,
               string contact,
               int constructionYear,
               int sellingPrice,
               int rentingPrice,
               RealEstateType type,
               string userId)
        {
            bool forSale = false;
            bool forRent = false;

            if (sellingPrice > 0)
            {
                forSale = true;
            }
            if (rentingPrice > 0)
            {
                forRent = true;
            }
            if (rentingPrice < 0 && sellingPrice < 0)
            {
                throw new ArgumentException("at least one of rentingPrice or sellingPrice should be > 0");
            }
            var newRealEstate = new RealEstate
            {
                Title = title,
                Description = description,
                Address = address,
                Contact = contact,
                ConstructionYear = constructionYear,
                SellingPrice = sellingPrice,
                RentingPrice = rentingPrice,
                CanBeRented = forRent,
                CanBeSold = forSale,
                Type = type,
                UserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate;
        }

        public IQueryable<RealEstate> GetRealEstateDetails(int id)
        {
            return this.realEstates
               .All()
               .Where(g => g.Id == id);
        }

        public List<RealEstate> GetPublicRealEstates(int skip, int take)
        {
            var publicRealEstates = this.realEstates
                .All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take)
                .ToList();
            return publicRealEstates;
        }
    }
}
