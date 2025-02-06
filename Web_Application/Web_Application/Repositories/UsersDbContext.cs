using Microsoft.EntityFrameworkCore;
using Web_Application.Models;

namespace Web_Application.Repositories
{
    public class UsersDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Email = "admin@example.com",
                    Password = "admin123",
                    Role = "Admin"
                }
                );

        }
    }
}
