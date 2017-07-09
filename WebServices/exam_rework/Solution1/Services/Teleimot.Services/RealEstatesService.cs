namespace Teleimot.Services
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Data.Common.Contracts;
    using Common;

    public class RealEstatesService : IRealEstatesService
    {
        private readonly IDbRepository<RealEstate> realEstates;

        public RealEstatesService(IDbRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public int Create(RealEstate realEstate)
        {
            if (realEstate.SellingPrice > 0)
            {
                realEstate.ForSale = true;
            }

            if (realEstate.RentingPrice > 0)
            {
                realEstate.ForRent = true;
            }

            // at least forSale/forRent should be true
            if (realEstate.SellingPrice <= 0 && realEstate.RentingPrice <= 0 )
            { 
                throw new ArgumentException(RealEstateConstants.AtLeastForSaleOrRentException);
            }

            this.realEstates.Add(realEstate);
            this.realEstates.Save();

            return realEstate.Id;  
        }

        public IEnumerable<RealEstate> Get(int take, int skip)
        {
            var realEstates = this.realEstates
                                .All()
                                .OrderByDescending(x => x.CreatedOn)
                                .Skip(skip)
                                .Take(take)
                                .ToList();
            return realEstates;
        }

        public IEnumerable<RealEstate> GetDetailsById(int id)
        {
            return this.realEstates
                   .All()
                   .Where(g => g.Id == id).ToList();
        }
    }
}
