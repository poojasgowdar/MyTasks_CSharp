using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public  class IRepository<Movie> where Movie :class
    {
        public IEnumerable<Movie>? GetAll { get; set; }

        public void FilterByTitle(Movie movie);
        public void FilterByYear(Movie movie);
    }
}
