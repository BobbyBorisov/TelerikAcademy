using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieApplication.Models;
using MovieApplication.Controllers;
using MovieApplication.Areas.Administrator.ViewModels;

namespace MovieApplication.Areas.Administrator.Controllers
{
    public class MoviesAdminController : AdminController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: /Administrator/MoviesAdmin/
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: /Administrator/MoviesAdmin/Details/5
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

        // GET: /Administrator/MoviesAdmin/Create
        public ActionResult Create()
        {
            var genres = db.Genres.Where(x => x.Name != "all").Select(GenreViewModel.FromGenre).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Genres = genres;

            return View();
        }

        // POST: /Administrator/MoviesAdmin/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: /Administrator/MoviesAdmin/Edit/5
        public ActionResult Edit(int? id)
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
            var genres = db.Genres.Where(x=>x.Name!="all").Select(GenreViewModel.FromGenre).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Genres = genres;

            return View(movie);
        }

        // POST: /Administrator/MoviesAdmin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var genres = db.Genres.Where(x => x.Name != "all").Select(GenreViewModel.FromGenre).ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Genres = genres;
            return View(movie);
        }

        // GET: /Administrator/MoviesAdmin/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Administrator/MoviesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
