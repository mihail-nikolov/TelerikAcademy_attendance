namespace Teleimot.Web.Api.Models.RealEstates
{
    using System;
    using AutoMapper;
    using Teleimot.Data.Models;
    using Teleimot.Web.Api.Infrastructure;

    public class GetRealEstateDetailsReponseModel : BaseRealEstateModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public string Address { get; set; }

        public int ConstructionYear { get; set; }

        public string Type { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            // custom mappings needed only for properties with different names/type 
            configuration.CreateMap<RealEstate, GetRealEstateDetailsReponseModel>("GetRealEstateDetailsReponseModel")
                .ForMember(r => r.Type, opts => opts.MapFrom(r => r.Type.ToString()))
                .ForMember(r => r.CanBeSold, opts => opts.MapFrom(r => r.ForSale))
                .ForMember(r => r.CanBeRented, opts => opts.MapFrom(r => r.ForRent));
        }
    }
}