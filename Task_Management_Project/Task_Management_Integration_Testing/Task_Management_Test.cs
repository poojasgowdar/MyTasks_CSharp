using DTOs.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_Integration_Testing
{
    public class Task_Management_Test : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public Task_Management_Test(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    if (descriptor != null) services.Remove(descriptor);

                    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));

                    using (var scope = services.BuildServiceProvider().CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                        dbContext.Database.EnsureDeleted(); //reset the database for fresh tests every time.
                        dbContext.Database.EnsureCreated(); //reset the database for fresh tests every time.

                        dbContext.TaskItems.Add
                        (new TaskItem
                        {
                            Title = "Complete API Documentation",
                            Description = "Write and update API documentation for the project.",
                            Status = "Pending",
                            DueDate = new DateTime(2025, 03, 15)
                        });
                        dbContext.TaskItems.Add
                        (new TaskItem
                        {
                            Title = "Integration Testing",
                            Description = "Performing Integration Testing.",
                            Status = "Completed",
                            DueDate = new DateTime(2025, 03, 10)
                        });
                        dbContext.SaveChanges();
                    }
                });
            });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllTasks_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/Task/GetAllTasks");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetById_ReturnsCorrectTaskItem()
        {
            var response = await _client.GetAsync("/api/Task/GetTaskById/1");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var taskItem = JsonConvert.DeserializeObject<TaskDto>(content);
            Assert.Equal("Complete API Documentation", taskItem?.Title);
        }

        [Fact]
        public async Task AddTask_ReturnsCreated()
        {
            var newTask = new TaskDto
            {
                Title = "Integration Testing",
                Description = "Performing Integration Testing.",
                Status = "Completed",
                DueDate = new DateTime(2025, 03, 10)
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newTask), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Task/CreateNewTask", jsonContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateTestItem_ReturnsUpdated()
        {
            var updateTask = new TaskDto
            {
                Title = "Integration Test",
                Description = "Performing Integration Testing.",
                Status = "Completed",
                DueDate = new DateTime(2025, 03, 10)
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateTask), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Task/UpdateTaskById/1", jsonContent);
            response.EnsureSuccessStatusCode();

            
        }

        [Fact]
        public async Task DeleteProduct_ReturnsSuccess()
        {
            var response = await _client.DeleteAsync("/api/Task/DeleteTaskById/1");
            response.EnsureSuccessStatusCode();
        }

    }
}
    
