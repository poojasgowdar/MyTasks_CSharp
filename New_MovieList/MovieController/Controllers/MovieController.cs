using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        // GET: api/movies/filter-by-title?title={title}
        [HttpGet("filter/title")]
        public IActionResult FilterByTitle([FromQuery] string title)
        {
            var movies = _movieService.FilterMoviesByTitle(title);
            return Ok(movies);
        }
    }
}
