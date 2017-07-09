namespace Teleimot.Services.Contracts
{
    using Data.Models;
    using System.Collections.Generic;

    public interface IRealEstatesService
    {
        int Create(RealEstate realEstate);

        IEnumerable<RealEstate> GetDetailsById(int id);

        IEnumerable<RealEstate> Get(int take, int skip);
    }
}
