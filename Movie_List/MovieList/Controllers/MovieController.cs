using Interface.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DataModels;
using Services.ServiceLayer;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieList.Controllers
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

        //[HttpGet("filter/genre")]
        //[SwaggerOperation(Summary = "Filter movies by genres")]
        //public IActionResult FilterByGenre([FromQuery] List<Genre> genres)
        //{
        //    if (genres == null || !genres.Any())
        //    {
        //        return BadRequest("Genres parameter is required.");
        //    }

        //    var movies = _movieService.FilterMoviesByGenre(genres);
        //    return Ok(movies);
        //}


    }
}
