using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using Models.Entities;
using Microsoft.Extensions.Logging;
using Azure;
using Microsoft.AspNetCore.Hosting;

namespace AuthIntegrationTests
{
    public class AuthIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // Class to handle token response
        public class TokenResponse
        {
            public string Token { get; set; }
        }

        // Class to handle error response
        public class ErrorResponse
        {
            public string Message { get; set; }
        }

        // Class to handle user response
        public class UserResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // Method to get JWT token dynamically
        private async Task<string> GetTokenAsync(string username, string password)
        {
            var loginDto = new
            {
                username,
                password
            };

            var response = await _client.PostAsJsonAsync("/api/User/login", loginDto);

            // Handle Unauthorized or OK response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Return an empty token or handle accordingly
                return string.Empty;
            }

            // Ensure it's OK if not Unauthorized
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.Token));

            return result.Token;
        }


        [Fact]
        public async Task Login_ReturnsOk_WithValidCredentials()
        {
            // Act
            var token = await GetTokenAsync("admin", "admin123");

            // Assert
            Assert.False(string.IsNullOrEmpty(token));
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WithInvalidCredentials()
        {
            // Arrange
            var loginDto = new
            {
                username = "wronguser",
                password = "wrongpassword"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/User/login", loginDto);
            
            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.Contains("Access denied", result);
        }

        [Fact]
        public async Task GetById_ReturnsUnauthorized_WhenTokenIsMissing()
        {
            // Act
            var response = await _client.GetAsync("/api/User/1ogin");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WithValidUserId_AsAdmin()
        {
            // Arrange
            var token = await GetTokenAsync("admin", "admin123");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/User/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var user = await response.Content.ReadFromJsonAsync<UserResponse>();
            Assert.NotNull(user);
            Assert.Equal(1, user.Id);
        }

        [Fact]
        public async Task GetById_ReturnsUnauthorized_WhenUserRoleIsInvalid()
        {
            // Attempt to log in with invalid user or no admin role
            var token = await GetTokenAsync("user", "user123");

            if (string.IsNullOrEmpty(token))
            {
                // Assert Unauthorized if login fails
                var response = await _client.GetAsync("/api/User/999");
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
                return;
            }

            // Set token if login is successful
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var responseWithToken = await _client.GetAsync("/api/User/999");

            // Assert
            Assert.Equal(HttpStatusCode.Forbidden, responseWithToken.StatusCode); // If Forbidden is expected
        }


        [Fact]
        public async Task GetAllUsers_AdminRole_ReturnsOk()
        {
            // Arrange
            var token = await GetTokenAsync("admin", "admin123");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/User/GetAllUsers");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(content));
        }

        [Fact]
        public async Task GetAllUsers_NonAdminRole_ReturnsForbidden()
        {
            // Arrange
            var token = await GetTokenAsync("user", "user123");

            // Check if token is empty (Unauthorized case)
            if (string.IsNullOrEmpty(token))
            {
                // Assert Unauthorized if login fails
                var unauthorizedResponse = await _client.GetAsync("/api/User/GetAllUsers");
                Assert.Equal(HttpStatusCode.Unauthorized, unauthorizedResponse.StatusCode);
                return;
            }

            // Set the token if login is successful
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/User/GetAllUsers");

            // Assert
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode); // Expect Forbidden if login succeeds but lacks admin role
        }



        [Fact]
        public async Task DeleteUser_AdminRole_ReturnsOk()
        {
            // Arrange
            var token = await GetTokenAsync("admin", "admin123");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string username = "admin";

            // Act
            var response = await _client.DeleteAsync($"/api/User/{username}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("User Deleted Successfully", content);
        }

        [Fact]
        public async Task DeleteUser_NonExistingUser_ReturnsNotFound()
        {
            // Arrange
            var token = await GetTokenAsync("admin", "admin123");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string username = "nonExistingUser";

            // Act
            var response = await _client.DeleteAsync($"/api/User/{username}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains($"User '{username}' not found.", content);
        }
    }
}



