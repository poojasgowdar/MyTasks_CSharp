using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceLayer;

namespace MovieController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetMoviesByTitle([FromQuery] string title)
        {
            // Retrieve the movies from the service
            var movies = _movieService.GetMovies();

            // Check if the movie list is null or empty
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies available.");
            }

            // If title is provided, filter movies by title
            if (!string.IsNullOrEmpty(title))
            {
                // Filter movies with a case-insensitive match
                movies = movies.Where(m => !string.IsNullOrEmpty(m.Title) && m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // If no movies match the title filter, return NotFound
            if (!movies.Any())
            {
                return NotFound($"No movies found with the title containing '{title}'.");
            }

            // Return the filtered movies
            return Ok(movies);
        }







    }
}
