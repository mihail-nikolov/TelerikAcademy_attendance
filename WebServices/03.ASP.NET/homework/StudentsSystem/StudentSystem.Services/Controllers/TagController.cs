namespace StudentSystem.Services.Controllers
{
    using CodeFirst.Data;
    using CodeFirst.Models;
    using System.Linq;
    using System.Web.Http;

    public class TagController : ApiController
    {
        private readonly IRepository<Tag> data;

        public TagController()
        {
            this.data = new EfGenericRepository<Tag>(new ForumContext());
        }

        public IHttpActionResult Get()
        {
            var tags = this.data.All().Select(t => t.Text).ToList();
            return this.Ok(tags);            
        }

        public IHttpActionResult Get(int id)
        {

            var tag = data.GetById(id);

            if (tag == null)
            {
                return this.NotFound();
            }

            return this.Ok(tag.Text);
        }
    }
}