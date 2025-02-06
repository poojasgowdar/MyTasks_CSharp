using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using User_Endpoint_API.Models;

namespace User_Endpoint_API.Context
{
    public class AppDbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        private readonly IConfiguration _configuration;

       
        public AppDbcontext(DbContextOptions<AppDbcontext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  default admin user
            //var adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123");
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                UserName = "admin",
                PasswordHash = "Admin@123",
                Role = "Admin"

            });
        }

    }
}

