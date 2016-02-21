namespace FitnessSystem.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Exercises;
    using Microsoft.AspNet.Identity;
    using Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class ExercisesController : BaseController
    {
        private readonly IExercisesServices exercises;
        private readonly ICategoriesService categories;

        public ExercisesController(IExercisesServices exercises, ICategoriesService categories)
        {
            this.exercises = exercises;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var exercises = this.exercises.GetAll().To<ExerciseLinkModel>().ToList();
            return this.View(exercises);
        }

        [Authorize]
        public ActionResult MyExercises()
        {
            var exercises = this.exercises.GetByUser(this.User.Identity.GetUserId()).To<ExerciseLinkModel>().ToList();
            return this.View(exercises);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateNew()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ExerciseEditViewModel newModel)
        {
            //var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            //var userManager = new UserManager<ApplicationUser>(store);
            //ApplicationUser user = userManager.FindByNameAsync(this.User.Identity.Name).Result;
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            var exercise = this.Mapper.Map<Exercise>(newModel);
            exercise.AuthorId = userId;
            this.exercises.Create(exercise);
            // this.categories.AddExercise(exercise);

            return this.Redirect("/");
        }

        public ActionResult Details(int id)
        {
            var exercise = this.Mapper.Map<ExerciseFullViewModel>(this.exercises.GetById(id));
            return this.View(exercise);
        }
    }
}
