using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        List<Movie> FilterMoviesByTitle(string title);
        //List<Movie> FilterMoviesByGenre(List<string> genres);  
        //object FilterMoviesByGenre(List<Genre> genres);
    }
}
