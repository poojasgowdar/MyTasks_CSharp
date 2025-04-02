using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthIntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                // 1. Remove the existing DbContext registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<UserDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // 2. Add In-Memory DbContext for testing
                services.AddDbContext<UserDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });

               // 3. Build the service provider and apply migrations
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
                    db.Database.EnsureCreated();
                    SeedTestData(db); // Optional: Seed data for tests
                }
            });
        }
        private void SeedTestData(UserDbContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        UserName = "admin",
                        Password = "admin123",
                        Role = "Admin"
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "user",
                        Password = "user123",
                        Role = "User"
                    }
                );
                db.SaveChanges();
            }
        }

    }
}

