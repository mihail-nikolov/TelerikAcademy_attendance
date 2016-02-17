using System.Collections.Generic;
using TwitterLikeSystem.Infrastructure;
using TwitterLikeSystem.Models;

namespace TwitterLikeSystem.ViewModels
{
    public class TweetViewModel : IMapFrom<Tweet>
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}