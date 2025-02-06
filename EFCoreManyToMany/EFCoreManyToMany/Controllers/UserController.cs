using AutoMapper;
using EFCoreManyToMany.Database;
using EFCoreManyToMany.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usercontroller : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public Usercontroller(BookDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //GET:api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            if(users ==null)
            {
                return NotFound();
            }
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return Ok(userDtos);
        }

        //PUT :api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            var user =_mapper.Map<User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }









        //FromSql Raw SQL Query
        [HttpGet("GetUserByUserName/{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
           // var user1 = _context.Users.FirstOrDefault(x => x.UserName == userName);
            var user = _context.Users.FromSql
           ($"SELECT * FROM Users WHERE UserName = {userName}")
        .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);

        }


    }
}
