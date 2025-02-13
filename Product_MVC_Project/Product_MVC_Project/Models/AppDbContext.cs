using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Product_MVC_Project.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasData
            (
                new Product { Id = 1, Name="Bluetooth",  Price=50000},
                new Product { Id = 2, Name="HeadPhones", Price=70000},
                new Product { Id = 3, Name="Wireless HeadPhone", Price=90000 }
            );
        }
    }
}
