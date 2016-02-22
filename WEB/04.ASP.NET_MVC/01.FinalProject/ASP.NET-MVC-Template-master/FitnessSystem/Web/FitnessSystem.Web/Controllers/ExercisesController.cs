﻿namespace FitnessSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Categories;
    using ViewModels.Exercises;

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
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var exercises = this.exercises.GetAll().To<ExerciseLinkModel>().ToList();
            DataSourceResult result = exercises.ToDataSourceResult(request);
            return this.Json(result);
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
            var categories = this.categories.GetAllVisible().To<CategorySimpleViewModel>().ToList();
            var categoriesSelectList = new SelectList(categories, "Id", "Name");

            this.ViewBag.categories = categoriesSelectList;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseEditViewModel newModel)
        {
            string userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.Redirect("~/Exercises/MyExercises");
            }

            var exercise = this.Mapper.Map<Exercise>(newModel);
            exercise.AuthorId = userId;
            this.exercises.Create(exercise);

            this.TempData["notification"] = "Exercise created!";
            return this.Redirect("~/Exercises/MyExercises");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditExercise(int id = 0)
        {
            if (id == 0)
            {
                return this.Redirect("~/Exercises");
            }

            var exercise = this.exercises.GetById(id);

            if (this.User.Identity.GetUserId() != exercise.AuthorId)
            {
                this.TempData["notification"] = "You are not the author of the exercise";
                return this.Redirect("~/Exercises/MyExercises");
            }

            var categories = this.categories.GetAllVisible().To<CategorySimpleViewModel>().ToList();
            var categoriesSelectList = new SelectList(categories, "Id", "Name");
            this.ViewBag.categories = categoriesSelectList;

            var exerciseToEdit = this.Mapper.Map<ExerciseEditViewModel>(exercise);
            return this.View(exerciseToEdit);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ExerciseEditViewModel exercise)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData["notification"] = "You are not the Author!";
                return this.RedirectToAction("Index");
            }

            var entity = this.Mapper.Map<Exercise>(exercise);
            this.exercises.Update(entity);

            this.TempData["notification"] = "Exercise edited!";
            return this.Redirect("~/Exercises/MyExercises");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return this.Redirect("~/Exercises");
            }

            var exercise = this.exercises.GetById(id);

            if (this.User.Identity.GetUserId() != exercise.AuthorId)
            {
                this.TempData["notification"] = "You are not the author of the exercise";
                return this.Redirect("~/Exercises");
            }

            this.exercises.Delete(id);

            this.TempData["notification"] = "exercise removed!";
            return this.Redirect("~/Exercises/MyExercises");
        }

        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return this.Redirect("~/Exercises");
            }

            var exercise = this.Mapper.Map<ExerciseFullViewModel>(this.exercises.GetById(id));
            return this.View(exercise);
        }
    }
}
