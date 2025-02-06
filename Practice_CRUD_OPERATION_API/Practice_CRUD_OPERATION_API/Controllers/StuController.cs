using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_CRUD_OPERATION_API.Context;
using Practice_CRUD_OPERATION_API.Models;
using Practice_CRUD_OPERATION_API.ViewModels;
namespace Practice_CRUD_OPERATION_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        public StuController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //List<BookDto> bookDtos = new List<BookDto>();
            var students = _context.Students.Include(x => x.Course).ToList();
            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentDtos);

        }
        [HttpPost]
        public IActionResult Post([FromBody] StudentDto studentdto)
        {
            var students = _mapper.Map<Student>(studentdto);
            _context.Students.Add(students);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] StudentDto studentdto)
        {
            var existingbook = _context.Students.Where(b => b.StudentId == id).FirstOrDefault();
            _mapper.Map(studentdto, existingbook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Student = _context.Students.Find(id);
            _context.Students.Remove(Student);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Student = _context.Students.Include(x => x.Course).FirstOrDefault(b => b.StudentId == id);
            var studentdto = _mapper.Map<StudentDto>(Student);
            return Ok(studentdto);
        }
    }
}
