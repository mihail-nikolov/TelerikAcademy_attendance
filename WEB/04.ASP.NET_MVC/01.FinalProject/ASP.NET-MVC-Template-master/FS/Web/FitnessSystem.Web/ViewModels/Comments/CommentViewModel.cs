namespace FitnessSystem.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(2, ErrorMessage = "min len: {1}")]
        public string Content { get; set; }

        public virtual string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.NickName));
        }
    }
}
