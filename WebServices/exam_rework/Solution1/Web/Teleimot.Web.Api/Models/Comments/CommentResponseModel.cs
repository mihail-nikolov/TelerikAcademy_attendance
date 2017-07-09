namespace Teleimot.Web.Api.Models.Comments
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure;

    public class CommentResponseModel: BaseCommentModel, IHaveCustomMappings, IMapFrom<Comment>
    {
        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            // custom mappings needed only for properties with different names/type 
            configuration.CreateMap<Comment, CommentResponseModel>("CommentResponseModel")
                .ForMember(c => c.UserName, opts => opts.MapFrom(c => c.User.UserName));
        }
    }
}