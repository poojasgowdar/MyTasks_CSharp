using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public  interface IMovieService
    {
        List<Movie> GetMovies();
        List<Movie> FilterMoviesByTitle(string title);
    }
}
