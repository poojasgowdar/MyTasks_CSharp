using AutoMapper;
using Dtos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POne_to_One.Entities;

namespace OneToOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper =  mapper;
        }

        [HttpGet] 
        public IActionResult GetStudents()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentDtos);
        }

    }
}
