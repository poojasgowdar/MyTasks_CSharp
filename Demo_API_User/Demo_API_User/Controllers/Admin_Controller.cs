using Demo_API_User.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;

namespace Demo_API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Admin_Controller(IConfiguration configuration)
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
                var token = JWTHelperToken.GenerateToken(request.Username, _configuration["Jwt:Key"], 60);
                return Ok(new { Token = token });
            }

            // Return Unauthorized if credentials are invalid
            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
