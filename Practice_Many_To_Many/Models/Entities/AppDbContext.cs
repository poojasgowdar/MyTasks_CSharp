using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
           .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<Product>().HasData(
                 new Product { ProductId = 1, ProductName = "Laptop"},
                 new Product { ProductId = 2, ProductName = "Smartphone" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Computers" }
            );

             modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },  // Laptop → Electronics
                new ProductCategory { ProductId = 1, CategoryId = 2 },  // Laptop → Computers
                new ProductCategory { ProductId = 2, CategoryId = 1 }   // Smartphone → Electronics
            );


            modelBuilder.Entity<Product>()
            .HasIndex(p => p.ProductName)
            .IsUnique();

            modelBuilder.Entity<Category>()
           .HasIndex(p => p.CategoryName)
           .IsUnique();
        }
    }
}
