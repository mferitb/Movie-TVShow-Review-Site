using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList(); 
            var tvShows = _context.TVShows.ToList(); 
            var viewModel = new MovieTVShowViewModel
            {
                Movies = movies,
                TVShows = tvShows
            };
            return View(viewModel);
        }

        public IActionResult MovieDetail(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound(); 
            }
            return View(movie); 
        }

        public IActionResult TVShowDetail(int id)
        {
            var tvShow = _context.TVShows.FirstOrDefault(t => t.Id == id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return View(tvShow); 
        }

        public IActionResult Error()
        {
            return View(); 
        }
    }
}
