using Microsoft.EntityFrameworkCore;
using PlayWrightCrudOperations.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightCrudOperations.DataAccess
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();
        }
    }
}
