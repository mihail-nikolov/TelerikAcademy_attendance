namespace Exam.Web.Api.Models.RealEstate
{
    using System;
    using AutoMapper;
    using Exam.Web.Api.Infrastructure.Mappings;
    using Data.Models;
    using System.Collections.Generic;
    using Comment;

    public class RealEstatePrivateDetailsResponseModel: BaseRealEstateModel, IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public int Id { get; set; }

        public string RealEstateType { get; set; }

        public string Contact { get; set; }

        public IEnumerable<CommentResponseModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstatePrivateDetailsResponseModel>()
                .ForMember(r => r.Contact, opts => opts.MapFrom(r => r.Contact))
                .ForMember(r => r.Comments, opts => opts.MapFrom(r => r.Comments))
                .ForMember(r => r.CreatedOn, opts => opts.MapFrom(r => r.CreatedOn))
                .ForMember(r => r.Address, opts => opts.MapFrom(r => r.Address))
                .ForMember(r => r.RealEstateType, opts => opts.MapFrom(r => r.Type.ToString())) //could also be null
                .ForMember(r => r.Description, opts => opts.MapFrom(r => r.Description))
                .ForMember(r => r.Id, opts => opts.MapFrom(r => r.Id))
                .ForMember(r => r.Title, opts => opts.MapFrom(r => r.Title))
                .ForMember(r => r.SellingPrice, opts => opts.MapFrom(r => r.SellingPrice))
                .ForMember(r => r.RentingPrice, opts => opts.MapFrom(r => r.RentingPrice))
                .ForMember(r => r.CanBeSold, opts => opts.MapFrom(r => r.CanBeSold))
                .ForMember(r => r.CanBeRented, opts => opts.MapFrom(r => r.CanBeRented));
        }
    }
}