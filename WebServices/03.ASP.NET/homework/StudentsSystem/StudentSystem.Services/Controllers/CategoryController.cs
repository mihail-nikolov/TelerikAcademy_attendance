namespace StudentSystem.Services.Controllers
{
    using CodeFirst.Data;
    using CodeFirst.Models;
    using System.Linq;
    using System.Web.Http;

    public class CategoryController : ApiController
    {
        private readonly IRepository<Category> data;

        public CategoryController()
        {
            this.data = new EfGenericRepository<Category>(new ForumContext());
        }

        public IHttpActionResult Get()
        {
            var categories = this.data.All().ToList();
            return this.Ok(categories);          
        }

        public IHttpActionResult Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.BadRequest("Category name cannot be null or empty.");
            }

            var category = this.data.All().ToList().FirstOrDefault(c => c.Name == name);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category.Name);
        }
    }
}