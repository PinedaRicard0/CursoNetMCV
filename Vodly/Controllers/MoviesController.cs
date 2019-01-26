using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vodly.Models;
using Vodly.ViewModels;

namespace Vodly.Controllers
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

        public ActionResult EditMovie(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                var viewModel = new MovieFormViewModel {
                    Movie = movie,
                    MoviesGenre = _context.Genres.ToList()
                };
                return View("MoviesForm", viewModel);
            }
                
            else
                return HttpNotFound();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies); 
        }

        public ActionResult NewMovie()
        {
            var viewModel = new MovieFormViewModel
            {
                MoviesGenre = _context.Genres.ToList()
            };
            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            var genreInDB = _context.Genres.SingleOrDefault(g => g.Id == movie.GenreId);
            
            if (movie.Id == 0)
            {
                movie.Genre = genreInDB;
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.StockQuantity = movie.StockQuantity;
                movieInDb.Genre = genreInDB;
            }         
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}