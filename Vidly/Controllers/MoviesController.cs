using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index( )
        {
            var movies = _context.Movies.ToList();

            if (User.IsInRole("CanManageMovies"))
            {
                return View(movies);
            }

            return View("ReadOnlyList",movies);

        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id.Value);

            return View(movie);
        }



        // Add movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add( [Bind(Include = "Name,Genre,NumberInStock,ReleaseDate")]  Movie movie)
        {
        
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                return Content("Unable to add movie");
            }


            
        }


        public ActionResult Edit(int? id)
        {

            if(id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var movieToUpdate = _context.Movies.Find(id);

            if (movieToUpdate == null)
            {
                return HttpNotFound();
            }



            return View(movieToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.Genre = movie.Genre;
            movieInDb.NumberInStock = movie.NumberInStock;
           

            _context.SaveChanges();

            return RedirectToAction("Index");
        }








    }
}