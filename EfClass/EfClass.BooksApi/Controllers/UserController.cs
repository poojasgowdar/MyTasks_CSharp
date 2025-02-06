using EfClass.Models.DBModels.DTOs;
using EfClass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfClass.BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _userService.GetUsers();
            return Ok(res);
        }
        [HttpGet("Id")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetUser(id);
            return Ok(result);
        }

        [HttpGet("email")]

        public IActionResult GetEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(UserDto userDto)
        {
            var result = _userService.SaveNewUser(userDto);
            return Ok(result);
        }
        


    }
}
//Using SQL Server as Database,use code first approach, creating ASP.NET CORE WEB API creating controller that will run swagger and using c# programming language
