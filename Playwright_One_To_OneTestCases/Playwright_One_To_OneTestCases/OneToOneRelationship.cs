using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Json;

namespace Playwright_One_To_OneTestCases
{
    [TestClass]
    public class OneToOneRelationship
    {
        private IPlaywright _playwright;
        private IAPIRequestContext _apiContext;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _apiContext = await _playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://localhost:7173/api/Student" // Replace with your API's base URL
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            await _apiContext.DisposeAsync();
            _playwright.Dispose();
        }

        [Test]
        public async Task GetStudentById_Returns200_WhenStudentExists()
        {
            // Replace with an existing student ID
            int Id = 1;
            var response = await _apiContext.GetAsync($"GetStudentBysId/{Id}");
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task GetStudentById_Returns404_WhenStudentNotFound()
        {
            // Using a non-existent student ID
            int studentId = 9999;
            var response = await _apiContext.GetAsync($"GetStudentsById/{studentId}");
            Assert.AreEqual(404, response.Status);
            var responseBody = await response.BodyAsync();
            StringAssert.Contains("Student Not Found", responseBody);
        }

        [Test]
        public async Task AddStudent_Returns200_WhenStudentIsCreated()
        {
            var studentDto = new
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 22
            };

            var response = await _apiContext.PostAsync("CreateNewStudent", new JsonContent(studentDto));
            Assert.AreEqual(200, response.Status);
            var responseBody = await response.BodyAsync();
            StringAssert.Contains("Student Created Successfully", responseBody);
        }

        [Test]
        public async Task AddStudent_Returns400_WhenInvalidData()
        {
            var invalidStudentDto = new
            {
                FirstName = "", // Invalid data (empty first name)
                LastName = "Doe",
                Age = 22
            };

            var response = await _apiContext.PostAsync("CreateNewStudent", new JsonContent(invalidStudentDto));
            Assert.AreEqual(400, response.Status);
        }

        [Test]
        public async Task UpdateStudent_Returns200_WhenStudentIsUpdated()
        {
            int studentId = 1; // Replace with an existing student ID
            var studentDto = new
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 23
            };

            var response = await _apiContext.PutAsync($"Updatestudent/{studentId}", new JsonContent(studentDto));
            Assert.AreEqual(200, response.Status);
            var responseBody = await response.BodyAsync();
            StringAssert.Contains("Student Updated Successfully", responseBody);
        }

        [Test]
        public async Task UpdateStudent_Returns404_WhenStudentNotFound()
        {
            int studentId = 9999; // Non-existing student ID
            var studentDto = new
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 23
            };

            var response = await _apiContext.PutAsync($"Updatestudent/{studentId}", new JsonContent(studentDto));
            Assert.AreEqual(404, response.Status);
            var responseBody = await response.BodyAsync();
            StringAssert.Contains("Student Not Found", responseBody);
        }
    }
    
}
