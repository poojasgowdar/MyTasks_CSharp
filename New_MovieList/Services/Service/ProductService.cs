using Models.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ProductService
    {
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
    }
}
