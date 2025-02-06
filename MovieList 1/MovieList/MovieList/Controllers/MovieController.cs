using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using MovieList.Services;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index(string titleFilter, string[] genreFilters, int page = 1)
        {
            var viewModel = _movieService.GetMovies(titleFilter, genreFilters, page);
            return View(viewModel);
        }
    }
}