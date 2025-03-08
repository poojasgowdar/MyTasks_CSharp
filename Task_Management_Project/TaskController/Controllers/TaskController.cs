using DTOs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace TaskController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("GetAllTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAll();
            if(tasks==null || !tasks.Any())
            {
                return NoContent();
            }
            return Ok(tasks);
        }

        [HttpGet("GetTaskById{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        [HttpPost("CreateNewTask")]
        public IActionResult Create([FromBody] TaskDto taskDto)
        {
            _taskService.Add(taskDto);
            return StatusCode(201);
        }

        [HttpPut("UpdateTaskById{id}")]
        public IActionResult Update(int id, TaskDto taskDto)
        {
            _taskService.Update(id, taskDto);
            return NoContent();
        }

        [HttpDelete("DeleteTaskById{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return NoContent();
        }
    }
}
