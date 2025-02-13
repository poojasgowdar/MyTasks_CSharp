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
                new Product { Id=1,Name="Bluetooth", Price=50000},
                new Product { Id=2,Name="HeadPhones",Price=80000},
                new Product { Id=3,Name="Hair Dryer",Price=90000}
            );
        }
    }
}
