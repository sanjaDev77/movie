using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using vidly.Models;
using Vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        private List<Movie> movies;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
             movies = _context.Movies.Include(c => c.Genre).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


 

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name= "Customer2"}
            
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //ViewData["Movie"] = movie;
            // return View(movie);
            //return View(movie);
            //return Content("hello world");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page=1, sortBy="name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies

        public ActionResult MoviesPagination(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }


        public ActionResult Index()
        {

            
            var movieViewModel = new MovieListViewModel()
            {
                Movies = movies
            };
            return View(movieViewModel);
        }


        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {

            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    return View(movie);
                }
                
            }

            return HttpNotFound();
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}