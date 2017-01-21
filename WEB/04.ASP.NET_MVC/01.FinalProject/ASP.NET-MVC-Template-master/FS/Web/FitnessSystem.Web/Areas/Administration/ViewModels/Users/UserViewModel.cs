namespace FitnessSystem.Web.Areas.Administration.ViewModels.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = 3)]
        public string Email { get; set; }

        public string NickName { get; set; }

        public bool IsVisible { get; set; }

        public int Comments { get; set; }

        public int Exercises { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>()
               .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments.Count));

            configuration.CreateMap<ApplicationUser, UserViewModel>()
               .ForMember(x => x.Exercises, opt => opt.MapFrom(x => x.Exercises.Count));
        }
    }
}