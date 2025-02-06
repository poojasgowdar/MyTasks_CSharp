namespace EFCoreManyToMany.Database
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
