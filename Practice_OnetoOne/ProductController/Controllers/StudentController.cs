using Dto.Dtos;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService _studentService;
        public StudentController(IService productService)
        {
            _studentService = productService;                                                                           
        }

        [HttpGet("GetAllstudents")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }
        
        [HttpGet("GetStudentById{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound(new { Message = "Student Not Found" });

            return Ok(student);
        }

        [HttpPost("CreateNewStudent")]
        public IActionResult AddStudent([FromBody] StudentDTO studentDto)
        {
            _studentService.AddStudent(studentDto);
            return Ok(new { Message = "Student Created Successfully" });
        }

        [HttpPut("UpdateById{id}")]
        public IActionResult UpdateStudent(int id,[FromBody] StudentDTO studentDto)
        {
            var result = _studentService.UpdateStudent(id, studentDto);
            if (!result)
                return NotFound(new { Message = "Student Not Found" });
            return Ok(new { Message = "Student Updated Successfully" });
        }
        [HttpDelete("DeleteById{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
            {
                return Ok(new { Message = "Student Not Found" });
            }
            _studentService.DeleteStudent(id);
            return Ok(new { Message = "Student Deleted Successfully" });


        }
    }
}
