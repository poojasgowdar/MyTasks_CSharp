using DemoExample_API.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoExample_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static List<User> _users = new List<User>();
        //{
        //    new User { Id = 1, Username = "admin", Role = "Admin" },
        //    new User { Id = 2, Username = "user1", Role = "User" }
        //};

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate credentials
            if (request.Username == _configuration["Jwt:Username"] &&
                request.Password == _configuration["Jwt:Password"])
            {
                // Generate JWT token
                var token = JWTTokenHelper.GenerateToken(request.Username, _configuration["Jwt:Key"], 60);
                return Ok(new { Token = token });
            }

            // Return Unauthorized if credentials are invalid
            return Unauthorized(new { Message = "Invalid username or password" });
        }
        //[HttpPost("add-user")]
        //[Authorize(Roles = "Admin")] // Ensure only Admins can access this endpoint
        //public IActionResult AddUser([FromBody] NewUserRequest newUser)
        //{
        //    // Validate that the username does not already exist
        //    if (_context.Users.Any(u => u.Username == newUser.Username))
        //    {
        //        return BadRequest(new { Message = "A user with this username already exists." });
        //    }

        //    // Hash the password
        //    var passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

        //    // Create a new user entity
        //    var user = new User
        //    {
        //        Username = newUser.Username,
        //        PasswordHash = passwordHash,
        //        Role = newUser.Role
        //    };

        //    // Add the new user to the database
        //    _context.Users.Add(user);
        //    _context.SaveChanges();

        //    return Ok(new
        //    {
        //        Message = "User added successfully.",
        //        User = new { user.Id, user.Username, user.Role }
        //    });
        //}


        [HttpDelete("delete-user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            if (user.Role == "Admin")
            {
                return BadRequest(new { Message = "Cannot delete an admin user." });
            }

            _users.Remove(user);

            return Ok(new { Message = "User deleted successfully." });
        }

    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class NewUserRequest
    {
        public string Username { get; set; }
        public string Role { get; set; } // Example: "User" or "Admin"
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords
        public string Role { get; set; } // User role
    }
}

