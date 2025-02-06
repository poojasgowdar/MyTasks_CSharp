using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.ServiceLayer
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch movies data synchronously from the JSON URL
        public List<Movie> GetMovies()
        {
            var url = "https://raw.githubusercontent.com/prust/wikipedia-movie-data/master/movies.json";
            var response = _httpClient.GetStringAsync(url).Result;  // .Result is used to block and get the result synchronously
            var movies = JsonSerializer.Deserialize<List<Movie>>(response);
            return movies;
        }
    }
}
