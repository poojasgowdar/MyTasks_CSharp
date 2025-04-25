using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductController_Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing"); //Important to trigger conditional logic
            builder.ConfigureServices(services =>
            {
                // Remove existing DbContext registrations (both options and context)
                var dbContextDescriptor = services.SingleOrDefault(
                     d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                if (dbContextDescriptor != null)
                    services.Remove(dbContextDescriptor);

                var contextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(AppDbContext));
                if (contextDescriptor != null)
                    services.Remove(contextDescriptor);

                // Add InMemory database
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));

                // Build service provider and seed test data
                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                dbContext.Products.AddRange(
                    new Product { Id = 1, Name = "Bluetooth", Price = 500 },
                    new Product { Id = 2, Name = "Laptop", Price = 1000 }
                );
                dbContext.SaveChanges();
            });
        }
    }
}

            
