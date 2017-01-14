namespace Exam.Web.Api.Models.Comment
{
    using System;
    using AutoMapper;
    using Exam.Web.Api.Infrastructure.Mappings;
    using Data.Models;

    public class CommentResponseModel: BaseCommentModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public string User { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentResponseModel>()
                .ForMember(c => c.CreatedOn, opts => opts.MapFrom(c => c.CreatedOn))
                .ForMember(c => c.Content, opts => opts.MapFrom(c => c.Content))
                .ForMember(c => c.User, opts => opts.MapFrom(c => c.User.UserName));
        }
    }
}