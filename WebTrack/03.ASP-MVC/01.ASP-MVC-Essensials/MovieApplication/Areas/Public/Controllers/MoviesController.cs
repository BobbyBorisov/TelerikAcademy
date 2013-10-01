using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieApplication.Models;

namespace MovieApplication.Areas.Public.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        public MoviesController()
        {
            //var genresList = new List<string>();
            //var genresQuery = db.Movies.Select(s => s.Genre).Distinct();

            //genresList.AddRange(genresQuery);
            //ViewBag.movieGenre = new SelectList(genresList);
        }

        // GET: /Public/Movies/
        public ActionResult Index()
        {
            var genres = db.Genres.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Genres = genres;
            return View(db.Movies.ToList());
        }

        // GET: /Public/Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Search(string genreId, string searchString)
        {
            //var genresList = new List<string>();
            //var genresQuery = db.Movies.Select(s => s.Genre).Distinct();

            //genresList.AddRange(genresQuery);
            //ViewBag.movieGenre = new SelectList(genresList);

            var movies = db.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(genreId))
            {
                var id = int.Parse(genreId);
                if (id != 1) // id = 1 equals to All Genres .. so skip filtering
                {
                    movies = movies.Where(m => m.Genre.Id == id);
                }
            }

            var genres = db.Genres.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Genres = genres;

            return View("Index",movies);
        }
    }
}
