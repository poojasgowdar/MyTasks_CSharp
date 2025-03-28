using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_TestCases
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the existing DbContext
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddDbContext<AppDbContext>(options =>
                {
                   options.UseInMemoryDatabase("TestDb");
                });

               // Ensure database is created with test data
               var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();
                    db.Database.EnsureCreated();

                    // Seed test data
                    SeedTestData(db);
                }
            });
        }

        private void SeedTestData(AppDbContext db)
        {
               db.Products.AddRange(new List<Product>
               {
                    new Product { Id = 1, Name = "Laptop", Price = 1200, },
                    new Product { Id = 2, Name = "Phone", Price = 800,  }
               });
               db.SaveChanges();
            }
        }
    }
