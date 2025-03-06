using DTOs.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace EmployeeController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService _employeeService;
        public EmployeeController(IService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetEmployees()
        {
            var emp = _employeeService.GetEmployees();
            return Ok(emp);
        }

        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployee(int id)
        {
            var emp = _employeeService.GetById(id);
            if (emp == null)
            {
                return NotFound(new { Message = "Employee with ID Not found",id });
            }
            return Ok(emp);
        }

        [HttpPost("AddEmployee")]
        public IActionResult Add([FromBody] EmployeeDTO employeeDto)
        {
            _employeeService.Add(employeeDto);
            return StatusCode(201, "Employee Created Successfully");
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult Update(int id,EmployeeDTO employeeDto)
        {
            var result = _employeeService.UpdateById(id, employeeDto);
            if (!result)
            {
                return NotFound("Employee Not Found");
            }
            return Ok("Employee Updated Successfully");
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            var existingEmployee = _employeeService.GetById(id);
            if (existingEmployee == null)
                return NotFound("Employee Not Found");

            _employeeService.DeleteById(id);

            return NoContent();
        }
    }
}
