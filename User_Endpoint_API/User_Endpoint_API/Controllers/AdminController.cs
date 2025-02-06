using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Endpoint_API.Context;
using User_Endpoint_API.Models;

namespace User_Endpoint_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public AdminController(AppDbcontext context)
        {
            _context = context;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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


    }
}
