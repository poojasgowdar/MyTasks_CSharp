using dtos.dto;
using Interface.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace StudentsController.Controllers
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
        public IActionResult GetStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudentsById/{id}")]
        public IActionResult GetStudent(int id)
        {
            var students = _studentService.GetStudentById(id);
            if (students == null)
            {
                return NotFound(new { Message = "Student Not Found" });
            }
            return Ok(students);
        }

        [HttpPost("CreateNewStudent")]
        public IActionResult AddStudent([FromBody] StudentDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Invalid student data.");
            }

            _studentService.Add(studentDto);
            return Ok(new { Message = "Student Created Successfully" });
        }

        [HttpPut("Updatestudent")]
        public IActionResult Update(int id,[FromBody]StudentDTO studentDto)
        {
            var result = _studentService.UpdateById(id, studentDto);
            if (!result)
            {
                return NotFound(new { Message = "Student Not Found" });
            }
            return Ok(new { Message = "Student Updated Successfully" });
        }
        [HttpDelete("DeleteStudentById")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
            {
                return Ok(new { Message = "Student Not Found" });
            }
            _studentService.DeleteById(id);
            return Ok(new { Message = "Student Deleted Successfully" });

        }


    }
}
