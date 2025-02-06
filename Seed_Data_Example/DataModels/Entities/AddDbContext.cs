using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entities
{
    public class AddDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(

            new Product { ProductId = 1, Name = "Mobile",  Price = 50.0M},
            new Product { ProductId = 2, Name = "Charger", Price = 60.0M},
            new Product { ProductId = 3, Name = "Battery",  Price = 20.0M},
            new Product { ProductId = 4, Name = "Ear Phones", Price = 10.0M },
            new Product { ProductId = 5, Name = "Watches", Price = 70.0M },
            new Product { ProductId = 6, Name = "Bottle", Price = 70.0M },
            new Product { ProductId = 7, Name = "Box", Price = 20.0M },
            new Product { ProductId = 8, Name = "Notepad", Price = 10.0M },
            new Product { ProductId = 9, Name = "Bag", Price = 70.0M },
            new Product { ProductId = 10, Name = "Head Phones", Price = 70.0M }


            );
        }
    }
}
