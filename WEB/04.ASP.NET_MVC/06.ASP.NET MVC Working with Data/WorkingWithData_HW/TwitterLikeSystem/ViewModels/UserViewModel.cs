using System.Collections.Generic;
using TwitterLikeSystem.Infrastructure;
using TwitterLikeSystem.Models;

namespace TwitterLikeSystem.ViewModels
{
    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}