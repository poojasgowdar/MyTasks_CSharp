using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
    public class Movie
    {
        public string? Title { get; set; }
        public int Year { get; set; }
        public List<string>? Cast { get; set; }
        public List<string>? Genres { get; set; }
        public string? Extract { get; set; }
        public string? Thumbnail { get; set; }


        //public Movie()
        //{
        //    Cast = new List<string>();
        //    Genres = new List<Genre>(); 
        //}
    }
}
