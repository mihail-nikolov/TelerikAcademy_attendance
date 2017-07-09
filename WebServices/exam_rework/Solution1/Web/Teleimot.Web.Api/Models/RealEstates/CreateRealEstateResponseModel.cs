namespace Teleimot.Web.Api.Models.RealEstates
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure;

    public class CreateRealEstateResponseModel: BaseRealEstateModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, CreateRealEstateResponseModel>("CreateRealEstateResponseModel")
                         .ForMember(r => r.CanBeSold, opts => opts.MapFrom(r => r.ForSale))
                         .ForMember(r => r.CanBeRented, opts => opts.MapFrom(r => r.ForRent));
        }
    }
}