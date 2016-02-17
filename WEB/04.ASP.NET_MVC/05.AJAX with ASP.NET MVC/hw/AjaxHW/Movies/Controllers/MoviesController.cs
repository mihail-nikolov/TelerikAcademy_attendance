using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Movies.Models;
using Movies.ViewModels;
using Movies.Data;
using EntityFramework.Extensions;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesDbContext moviesDb = new MoviesDbContext();

        public ActionResult Index()
        {
            var movies = this.moviesDb.Movies
                .ProjectTo<MovieViewModel>();

            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                string actorName = model.LeadingMaleRole.Name;
                string actressName = model.LeadingFemaleRole.Name;
                string directorName = model.Director.Name;
                string studioName = model.Studio.Name;

                var newActor = this.moviesDb.Actors.First(x => x.Name == actorName);
                var newActress = this.moviesDb.Actresses.First(x => x.Name == actressName);
                var newDirector = this.moviesDb.Directors.First(x => x.Name == directorName);
                var newStudio = this.moviesDb.Studios.First(x => x.Name == studioName);
                

                var newMovie = new Movie()
                {
                    Title = model.Title,
                    Year = model.Year,
                    Studio = newStudio,
                    Director = newDirector,
                    LeadingFemaleRole = newActress,
                    LeadingMaleRole = newActor
                };

                this.moviesDb.Movies.Add(newMovie);
                this.moviesDb.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                string actorName = model.LeadingMaleRole.Name;
                string actressName = model.LeadingFemaleRole.Name;
                string directorName = model.Director.Name;
                string studioName = model.Studio.Name;

                var newActor = this.moviesDb.Actors.First(x => x.Name == actorName);
                var newActress = this.moviesDb.Actresses.First(x => x.Name == actressName);
                var newDirector = this.moviesDb.Directors.First(x => x.Name == directorName);
                var newStudio = this.moviesDb.Studios.First(x => x.Name == studioName);

                var movieForEdit = this.moviesDb.Movies.First(x => x.Id == model.Id);

                movieForEdit.Title = model.Title;
                movieForEdit.Year = model.Year;
                movieForEdit.Studio = newStudio;
                movieForEdit.Director = newDirector;
                movieForEdit.LeadingMaleRole = newActor;
                movieForEdit.LeadingFemaleRole = newActress;

                this.moviesDb.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movieForEdit = this.moviesDb.Movies
                .Where(x => x.Id == id)
                .ProjectTo<MovieViewModel>()
                .FirstOrDefault();

            return View(movieForEdit);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movieForEdit = this.moviesDb.Movies
                .Where(x => x.Id == id)
                .ProjectTo<MovieViewModel>()
                .FirstOrDefault();

            if (movieForEdit == null)
            {
                return HttpNotFound();
            }
            return View(movieForEdit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovieComfirm(int? id)
        {
            this.moviesDb.Movies.Delete(m => m.Id == id);
            this.moviesDb.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}