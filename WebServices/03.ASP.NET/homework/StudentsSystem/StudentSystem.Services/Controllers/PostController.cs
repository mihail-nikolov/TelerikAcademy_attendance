namespace StudentSystem.Services.Controllers
{
    using CodeFirst.Data;
    using CodeFirst.Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class PostController : ApiController
    {
        private readonly IRepository<Post> data;

        public PostController()
        {
            this.data = new EfGenericRepository<Post>(new ForumContext());
        }

        public IHttpActionResult Get()
        {
            var posts = data.All().ToList();
            return this.Ok(posts);     
        }

        public IHttpActionResult Get(int id)
        {
            var post = data.GetById(id);

            if (post == null)
            {
                return this.NotFound();
            }

            return this.Ok(post.Content);
        }

        public IHttpActionResult Post(SavePostRequestModel post)
        {
            var newPost = new Post()
            {
                Title = post.Title,
                CreatedOn = DateTime.Now,
                Content = post.Content,
                CategoryId = post.CategoryId
            };

            this.data.Add(newPost);
            this.data.SaveChanges();

            return this.Ok(newPost.PostId);
        }
    }
}