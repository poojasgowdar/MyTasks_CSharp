using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User_Endpoint_API.Context;
using User_Endpoint_API.Models;

namespace User_Endpoint_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbcontext _context;
        private readonly IMapper _mapper;
        public UserController(AppDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //User Login
        [HttpPost("login")]
        [Authorize(Roles = "User")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == loginUser.UserName && u.Password == loginUser.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("Your_Secret_Key"); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role) 
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        // CREATE USER 
        [HttpPost]
        [Authorize(Roles = "User")] 
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (_context.Users.Any(u => u.UserName == newUser.UserName))
            {
                return BadRequest("User already exists");
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Created("", newUser); 
        }
        // DELETE USER 
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")] 
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok("User deleted");
        }
 
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
    
}
