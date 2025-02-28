using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Product>()
        //    .HasIndex(p => p.Name)
        //    .IsUnique();

        //    modelBuilder.Entity<Product>()
        //    .Property(p => p.Price)
        //    .HasPrecision(18, 2);

        //    modelBuilder.Entity<Product>().HasData
        //    (
        //        new Product { Id = 1, Name = "Samsung", Price = 55000 },
        //        new Product { Id = 2, Name = "Nokia", Price = 54000 },
        //        new Product { Id = 3, Name = "Redmi", Price = 57000 }
        //    );



        //}

    }
}
