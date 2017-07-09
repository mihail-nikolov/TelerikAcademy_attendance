namespace Teleimot.Web.Api.Models.Users
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure;

    public class UserResponseModel: IHaveCustomMappings, IMapFrom<User>
    {
        public string UserName { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            // custom mappings needed only for properties with different names/type 
            configuration.CreateMap<User, UserResponseModel>("UserResponseModel")
                .ForMember(u => u.RealEstates, opts => opts.MapFrom(u => u.RealEstates.Count))
                .ForMember(u => u.Comments, opts => opts.MapFrom(u => u.Comments.Count))
                .ForMember(u => u.Rating, opts => opts.MapFrom(u => u.Ratings.Count == 0 ? 0 : u.Ratings.Average(r => r.Value)));
        }
    }
}