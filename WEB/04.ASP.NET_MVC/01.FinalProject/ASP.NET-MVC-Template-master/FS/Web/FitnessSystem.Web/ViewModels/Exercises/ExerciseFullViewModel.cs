namespace FitnessSystem.Web.ViewModels.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Comments;
    using Data.Models;
    using ForumSystem.Web.Infrastructure;
    using Infrastructure.Mapping;

    public class ExerciseFullViewModel : IMapFrom<Exercise>, IHaveCustomMappings
    {
        private ISanitizer sanitizer;

        public ExerciseFullViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual string Author { get; set; }

        public virtual int Votes { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Exercise, ExerciseFullViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
            configuration.CreateMap<Exercise, ExerciseFullViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author != null ? x.Author.NickName : "anonymous"));
            configuration.CreateMap<Exercise, ExerciseFullViewModel>()
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => v.Points) : 0));
        }
    }
}
