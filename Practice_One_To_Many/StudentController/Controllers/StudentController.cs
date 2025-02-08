using Dto.dtos;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService _studentService;
        public StudentController(IService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudentById{id}")]
        public IActionResult GetStudentsById(int id)
        {
            var students = _studentService.GetStudentById(id);
            if (students == null)
            {
                return NotFound(new { Message = "Student Not Found" });
            }
            return Ok(students);
        }

        [HttpPost("CreateNewStudent")]
        public IActionResult Add([FromBody]StudentDTO studentDto)
        {
            _studentService.Add(studentDto);
            return Ok("Student created Successfully");
        }
        [HttpPut("UpdateStudentById{id}")]
        public IActionResult Update(int id,[FromBody] StudentDTO studentDto)
        {
            var result = _studentService.Update(id, studentDto);
            if (!result)
            {
                return NotFound(new { Message = "Student Not Found" });
            }
            return Ok("Student Updated Successfully");

        }
        [HttpDelete("DeleteById{id}")]
        public IActionResult Delete(int id)
        {
            var students = _studentService.GetStudentById(id);
            if (students == null)
            {
                return NotFound(new { Message = "Student Not Found" });
            }
            return Ok("Student Deleted Successfully");
        }

    }
}
