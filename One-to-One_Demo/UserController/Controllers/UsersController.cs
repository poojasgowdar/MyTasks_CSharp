using DTOModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Context;
using Models.DbModels;

namespace UserController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        //Post: api/Users
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDTO)
        {
            if (userDTO == null || userDTO.UserProfile == null)
            {
                return BadRequest("User or UserProfile is null.");
            }

            try
            {
                // Map DTO to User Entity
                var user = new User
                {
                    UserName = userDTO.UserName,
                    UserProfile = new UserProfile
                    {
                        FirstName = userDTO.UserProfile.FirstName,
                        LastName = userDTO.UserProfile.LastName
                    }
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                // Map User Entity back to UserResponseDTO
                var responseDTO = new UserResponseDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserProfile = new UserProfileDto
                    {
                        FirstName = user.UserProfile.FirstName,
                        LastName = user.UserProfile.LastName
                    }
                };

                return CreatedAtAction(nameof(CreateUser), new { id = user.UserId }, responseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
