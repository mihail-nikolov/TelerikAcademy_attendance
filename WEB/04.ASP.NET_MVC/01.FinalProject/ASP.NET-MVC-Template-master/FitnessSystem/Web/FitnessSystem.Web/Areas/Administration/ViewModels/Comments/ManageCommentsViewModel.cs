namespace FitnessSystem.Web.Administration.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ManageCommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings, IMapTo<Category>
    {
        public int Id { get; set; }

        public string Exercise { get; set; }

        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "max len:{1}, min len: {2}.", MinimumLength = 2)]
        public string Content { get; set; }

        public virtual string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, ManageCommentsViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
            configuration.CreateMap<Comment, ManageCommentsViewModel>()
               .ForMember(x => x.Exercise, opt => opt.MapFrom(x => x.Exercise.Title));
        }
    }
}
