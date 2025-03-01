namespace MovieList.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Cast { get; set; }
        public List<string> Genres { get; set; }
        public string Thumbnail { get; set; }
    }

}
