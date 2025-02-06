using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie>? Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,  // Assuming you have an Id property
                    Title = "The Conjuring",
                    Year = 2013,
                    Cast = "Vera Farmiga, Patrick Wilson",
                    Genres = "Horror"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Inception",
                    Year = 2010,
                    Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt",
                    Genres = "Sci-Fi"
                }
            );
        }
    }
}
