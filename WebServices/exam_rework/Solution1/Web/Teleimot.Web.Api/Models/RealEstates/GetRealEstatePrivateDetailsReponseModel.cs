namespace Teleimot.Web.Api.Models.RealEstates
{
    using System.Collections.Generic;
    using AutoMapper;
    using Teleimot.Data.Models;
    using Comments;

    public class GetRealEstatePrivateDetailsReponseModel : GetRealEstateDetailsReponseModel
    {
        public string Contact { get; set; }

        public IEnumerable<CommentResponseModel> Comments { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, GetRealEstatePrivateDetailsReponseModel>("GetRealEstatePrivateDetailsReponseModel")
                 .ForMember(r => r.Comments, opts => opts.MapFrom(r => r.Comments))
                 .ForMember(r => r.Type, opts => opts.MapFrom(r => r.Type.ToString()))
                 .ForMember(r => r.CanBeSold, opts => opts.MapFrom(r => r.ForSale))
                 .ForMember(r => r.CanBeRented, opts => opts.MapFrom(r => r.ForRent));
        }
    }
}