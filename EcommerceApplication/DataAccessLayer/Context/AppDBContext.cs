using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class AppDBContext :DbContext
    {
        public DbSet<Product> Products { get; set; }  
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }

    }
}
