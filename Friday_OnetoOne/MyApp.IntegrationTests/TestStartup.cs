using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IntegrationTests
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // Build the service provider and seed data
            //var serviceProvider = services.BuildServiceProvider();
            //using var scope = serviceProvider.CreateScope();
            //var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //SeedTestData(dbContext); // Call a method to seed test data
        }
        //private void SeedTestData(AppDbContext dbContext)
        //{
        //    if (!dbContext.Students.Any())
        //    {
        //        var course = new Course { CourseName = "Mathematics" };
        //        var student = new Student { Id = 1, Name = "John", Email = "John@gmail.com", Course = course };

        //        dbContext.Students.Add(student);
        //        dbContext.SaveChanges();
        //        var students = dbContext.Students.Include(s => s.Course).ToList();
        //        Console.WriteLine(JsonConvert.SerializeObject(students, Formatting.Indented));

        //    }
        //}


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
