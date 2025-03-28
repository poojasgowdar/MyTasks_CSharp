using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskItem>().HasData
            (
               new TaskItem
               {
                   Id = 1,
                   Title = "Complete API Documentation",
                   Description = "Write and update API documentation for the project.",
                   Status = "Pending",
                   DueDate = new DateTime(2025, 03, 15)
               }

            );
        }
    }
}
