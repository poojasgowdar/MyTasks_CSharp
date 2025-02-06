using Microsoft.EntityFrameworkCore;
using Nest;

namespace E_Commerce_Application.DataAccessLayer
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Product>()
        //   .Property(p => p.Price)
        //   .HasPrecision(18, 2);

            ////Id is auto-generated
            //     modelBuilder.Entity<Product>()
            //    .Property(p => p.Id)
            //    .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        Id=1,
            //        Name = "Laptop",
            //        Description = "High-Performance",
            //        Price = 1200.50M,
            //        StockQuantity = 10,
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new Product
            //    {
            //        Id=2,
            //        Name = "Dell",
            //        Description = "Compatible",
            //        Price = 1201.50M,
            //        StockQuantity = 11,
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    });

        
    }
}
