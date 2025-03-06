using DTOs.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _userService.Login(loginDto);
            if (token == null)
            {
                return Unauthorized(new { Message = "Access denied. Please verify your credentials." });
            }
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound(new { Message =$"User with Id {id} not found."});
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public IActionResult GetByUsername(string username)
        {
            var user = _userService.GetUserByUsername(username);
            if (user == null)
                return NotFound(new { Message = "Invalid User Name.Please Enter a Valid User Name" });
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            var adminUsername = User.Identity?.Name;
            if (adminUsername == null)
                return Unauthorized("User is not authenticated.");

            return Ok(_userService.AddUser(userDto, adminUsername));
        }

        [HttpDelete("{username}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string username)
        {
            bool isDeleted = _userService.DeleteUser(username);
            if (!isDeleted)
            {
                return NotFound(new { Message = $"User '{username}' not found." });
            }
            return Ok("User Deleted Successfully");
        }

    }
}
