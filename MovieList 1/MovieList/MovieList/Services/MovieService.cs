using MovieList.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace MovieList.Services
{
    public class MovieService
    {
        private List<Movie> _movies;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const int PageSize = 50;

        public MovieService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private void LoadMoviesIfNeeded()
        {
            if (_movies == null)
            {
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Data", "movies.json");
                var jsonText = System.IO.File.ReadAllText("C:\\Users\\Pooja S\\Documents\\movies\\movies.json");
                _movies = JsonConvert.DeserializeObject<List<Movie>>(jsonText) ?? new List<Movie>();
            }
        }

        public MovieViewModel GetMovies(string titleFilter, string[] genreFilters, int page = 1)
        {
            LoadMoviesIfNeeded();

            IEnumerable<Movie> query = _movies;

            if (!string.IsNullOrWhiteSpace(titleFilter))
            {
                query = query.Where(m => m.Title.Contains(titleFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (genreFilters != null && genreFilters.Any())
            {
                query = query.Where(m => m.Genres != null &&
                                       m.Genres.Any(g => genreFilters.Contains(g)));
            }

            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            page = Math.Max(1, Math.Min(page, Math.Max(1, totalPages)));

            var movies = query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var allGenres = _movies
                .Where(m => m.Genres != null)
                .SelectMany(m => m.Genres)
                .Distinct()
                .OrderBy(g => g)
                .ToList();

            return new MovieViewModel
            {
                Movies = movies,
                CurrentPage = page,
                TotalPages = totalPages,
                TitleFilter = titleFilter,
                SelectedGenres = genreFilters?.ToList() ?? new List<string>(),
                AllGenres = allGenres
            };
        }
    }
}