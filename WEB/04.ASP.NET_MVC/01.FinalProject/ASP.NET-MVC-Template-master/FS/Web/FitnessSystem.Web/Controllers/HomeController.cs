namespace FitnessSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Exercises;

    public class HomeController : BaseController
    {
        private readonly IExercisesServices exercises;

        public HomeController(IExercisesServices exercises)
        {
            this.exercises = exercises;
        }

        public ActionResult Index()
        {
            var exercisesViewModel =
                this.Cache.Get(
                    "categories",
                    () => this.exercises.Get(5).To<ExerciseLinkModel>().ToList(),
                    5 * 30);

            return this.View(exercisesViewModel);
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}
