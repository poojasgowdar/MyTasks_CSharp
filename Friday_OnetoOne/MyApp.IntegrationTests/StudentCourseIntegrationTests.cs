using dtos.dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
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
    public class StudentCourseIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public StudentCourseIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            using (var scope = factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                SeedTestData(dbContext);
            }
        }
        private void SeedTestData(AppDbContext dbContext)
        {
            if (!dbContext.Students.Any())
            {
                var course = new Course { CourseName = "Java" };
                var student = new Student { Id = 1, Name = "John", Email = "John@gmail.com", Course = course };

                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                var students = dbContext.Students.Include(s => s.Course).ToList();
                Console.WriteLine(JsonConvert.SerializeObject(students, Formatting.Indented));

            }
        }

        [Fact]
        public async Task GetStudent_ReturnsStudentWithCourse()
        {
            // Arrange
            var Id = 1;

            // Act
            var response = await _client.GetAsync($"/api/student/GetStudentsById/{Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<Student>(content);

            // Assert
            Assert.NotNull(student);
            // Assert.Equal(Id, student.Id);
            Assert.NotNull(student.Course);
            Assert.Equal("Java", student.Course.CourseName);
        }

        [Fact]
        public async Task CreateStudent_ReturnsCreatedStudent()
        {
            // Arrange
            var studentDto = new StudentDTO
            {
                Name = "John",
                Email = "John@gmail.com",
                Course = new CourseDTO
                {
                    CourseName = "Mathematics"
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(studentDto), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/student/CreateNewStudent", content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var createdStudent = JsonConvert.DeserializeObject<StudentDTO>(responseBody);

            //Assert
            //Assert.NotNull(createdStudent);
            //Assert.Equal("John", createdStudent.Name);
            //Assert.NotNull(createdStudent.Course);
            //Assert.Equal("Mathematics", createdStudent.Course.CourseName);
        }

    }
}
