using Entities.Models;
using Interfaces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceLayer
{
    public class ServiceMovie : IService
    {
        private readonly IRepository<Movie> _movie;

        public ServiceMovie(IRepository<Movie> _movie)
        {
            _movie = Movie;
        }

        public IEnumerable<Movie>? GetAll()
        {
            return _movie.GetAll();
        }



        public void FilterByGenre(Movie movie)
        {
            movie_genre ={ 1.Horror,2.Comedy,}

        }



    }
}
