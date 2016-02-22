namespace FitnessSystem.Web.Administration.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ManageCommentsViewModel : IMapFrom<Comment>//, IHaveCustomMappings
    {
        public int Id { get; set; }

        public Exercise Exercise { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(2, ErrorMessage = "min len: {1}")]
        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        //public void CreateMappings(IMapperConfiguration configuration)
        //{
        //    configuration.CreateMap<Comment, ManageCommentsViewModel>()
        //        .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        //    configuration.CreateMap<Comment, ManageCommentsViewModel>()
        //       .ForMember(x => x.Exercise, opt => opt.MapFrom(x => x.Exercise.Title));
        //}
    }
}
