namespace Exam.Web.Api.Models.RealEstate
{
    using System;
    using AutoMapper;
    using Exam.Web.Api.Infrastructure.Mappings;
    using Data.Models;
    using System.Collections.Generic;

    public class CreatedRealEstateResponseModel : BaseRealEstateModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, CreatedRealEstateResponseModel>()
                .ForMember(r => r.Id, opts => opts.MapFrom(r => r.Id))
                .ForMember(r => r.Title, opts => opts.MapFrom(r => r.Title))
                .ForMember(r => r.SellingPrice, opts => opts.MapFrom(r => r.SellingPrice))
                .ForMember(r => r.RentingPrice, opts => opts.MapFrom(r => r.RentingPrice))
                .ForMember(r => r.CanBeSold, opts => opts.MapFrom(r => r.CanBeSold))
                .ForMember(r => r.CanBeRented, opts => opts.MapFrom(r => r.CanBeRented));
        }
    }
}