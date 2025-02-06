using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IService
    {
       public IEnumerable<Movie>? GetMovies { get; set; }

        public void FilterByName();
        public void FilterByGenre();
    }
}
