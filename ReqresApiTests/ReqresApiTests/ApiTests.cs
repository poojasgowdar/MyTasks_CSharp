using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReqresApiTests
{
    public class ApiTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://reqres.in/api/");
        }

        [TearDown]
        public void Cleanup()
        {
            _client?.Dispose();  
        }

        [Test]
        public async Task UserCrudFlow_ShouldSucceed()
        {
            // 1. POST - Create user
            var createRequest = new RestRequest("users", Method.Post);
            createRequest.AddJsonBody(new { name = "John", job = "Developer" });

            var createResponse = await _client.ExecuteAsync(createRequest);
            Assert.That(createResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

            var createdUser = JsonDocument.Parse(createResponse.Content).RootElement;
            string userId = createdUser.GetProperty("id").GetString();

     
            // 2. GET - Retrieve user (reqres.in only supports predefined user GET)
            var getRequest = new RestRequest("users/2", Method.Get);
            var getResponse = await _client.ExecuteAsync(getRequest);
            Assert.That(getResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            // 3. PUT - Update user
            var updateRequest = new RestRequest($"users/{userId}", Method.Put);
            updateRequest.AddJsonBody(new { name = "John Doe", job = "Senior Dev" });

            var updateResponse = await _client.ExecuteAsync(updateRequest);
            Assert.That(updateResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            // 4. DELETE - Delete user
            var deleteRequest = new RestRequest($"users/{userId}", Method.Delete);
            var deleteResponse = await _client.ExecuteAsync(deleteRequest);
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));

        }
    }
}

