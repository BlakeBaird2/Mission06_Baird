using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Baird.Models;

namespace Mission06_Baird.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        // Home page
        public IActionResult Index()
        {
            return View();
        }

        // About Joel page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Display all movies in the collection
        public IActionResult MovieList()
        {
            // Include Category navigation property to display category name
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        // GET: Show the Add Movie form
        [HttpGet]
        public IActionResult EnterMovie()
        {
            // Populate the category dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View();
        }

        // POST: Save a new movie to the database
        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                // Re-populate categories dropdown if validation fails
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        // GET: Show the Edit form for a specific movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Populate the category dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(movie);
        }

        // POST: Save changes to an existing movie
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedMovie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                // Re-populate categories dropdown if validation fails
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                return View(updatedMovie);
            }
        }

        // GET: Show delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Confirm deletion of a movie
        [HttpPost]
        public IActionResult DeleteConfirmed(int movieId)
        {
            var movie = _context.Movies.Find(movieId);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }
    }
}
