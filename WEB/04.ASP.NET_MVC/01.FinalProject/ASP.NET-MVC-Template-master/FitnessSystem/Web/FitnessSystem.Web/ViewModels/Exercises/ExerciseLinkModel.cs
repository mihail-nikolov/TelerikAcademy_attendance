namespace FitnessSystem.Web.ViewModels.Exercises
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ExerciseLinkModel : IMapFrom<Exercise>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string AuthorId { get; set; }

        public virtual string Author { get; set; }

        public virtual int Votes { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Exercise, ExerciseLinkModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
            configuration.CreateMap<Exercise, ExerciseLinkModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
            configuration.CreateMap<Exercise, ExerciseLinkModel>()
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => v.Points) : 0));
            configuration.CreateMap<Exercise, ExerciseLinkModel>()
                .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments.Any() ? x.Comments.Count : 0));
        }
    }
}
