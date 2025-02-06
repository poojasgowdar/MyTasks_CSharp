
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Context
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
               .Property(b => b.Price)
               .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "Science" },
                new Genre { Id = 3, Name = "Biography" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Price = 9.99m, PublishedYear = 1949, GenreId = 1 },
                new Book { Id = 2, Title = "A Brief History of Time", Author = "Stephen Hawking", Price = 14.99m, PublishedYear = 1988, GenreId = 2 },
                new Book { Id = 3, Title = "The Diary of a Young Girl", Author = "Anne Frank", Price = 12.50m, PublishedYear = 1947, GenreId = 3 }
            );
        }
    }
}
