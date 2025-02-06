using Interface.Interfaces;
using Models.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceLayer
{
    public class MovieService : IMovieService
    {

        private const string MoviesUrl = "https://raw.githubusercontent.com/prust/wikipedia-movie-data/master/movies.json";

        public List<Movie> GetMovies()
        {
            using var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(MoviesUrl).Result;

            return JsonConvert.DeserializeObject<List<Movie>>(response) ?? new List<Movie>();
        }

        public List<Movie> FilterMoviesByTitle(string title)
        {
            var movies = GetMovies();
            return movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

      
        public List<Movie> FilterMoviesByGenre(List<string> genres)
        {
            var movies = GetMovies();
            return movies.Where(m => m.Genres.Any(g => genres.Contains(g, StringComparer.OrdinalIgnoreCase))).ToList();
        }

       
        //public object FilterMoviesByGenre(List<Genre> genres)
        //{
        //    var movies = GetMovies();

        //    
        //    var genreStrings = genres.Select(g => g.ToString()).ToList();

        //    
        //    var filteredMovies = movies.Where(m => m.Genres.Any(g => genreStrings.Contains(g, StringComparer.OrdinalIgnoreCase))).ToList();

        //    return filteredMovies;
        //}
    }




}

