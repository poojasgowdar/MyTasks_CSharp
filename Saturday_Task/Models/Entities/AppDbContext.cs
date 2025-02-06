using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                 .HasIndex(c => c.Name)
                 .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProductCategory>()
                 .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Electronics" },
              new Category { Id = 2, Name = "Clothing" },
              new Category { Id = 3, Name = "Furniture" }
             );

            base.OnModelCreating(modelBuilder);
        }

        
        

    }
}
