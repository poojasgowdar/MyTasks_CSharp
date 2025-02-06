using DemoExample_API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace DemoExample_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate user credentials (in real app, validate against DB)
            if (request.Username == _configuration["Jwt:Username"] && request.Password == _configuration["Jwt:Password"])
            {
                // Generate JWT token
                var token = JWTTokenHelper.GenerateToken(request.Username, _configuration["Jwt:Key"], 60);
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }
}
