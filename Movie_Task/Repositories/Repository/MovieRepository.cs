using Entities.Models;
using Interfaces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class MovieRepository:IRepository
    {
        private readonly IRepository _repository;

        public MovieRepository(IRepository repository)
        {
            _repository = repository;
        }

        public void FilterByName(Movie movie)
        {
            
        }
        public void FilterByGenre(Movie movie)
        {

        }
    }
}
