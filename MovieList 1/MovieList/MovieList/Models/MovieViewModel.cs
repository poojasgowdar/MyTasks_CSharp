namespace MovieList.Models
{
    public class MovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string TitleFilter { get; set; }
        public List<string> SelectedGenres { get; set; }
        public List<string> AllGenres { get; set; }
    }
}
