using AutoMapper;
using DTOs.DTO;
using Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskManager _taskManager;
        public TaskService(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }
        public List<TaskDto> GetAll()
        {
            return _taskManager.GetAll();
        }
        public TaskDto GetById(int id)
        {
            return _taskManager.GetById(id);
        }
        public void Add(TaskDto taskDto)
        {
            _taskManager.Add(taskDto);
        }
        public bool Update(int id, TaskDto taskDto)
        {
            return _taskManager.Update(id, taskDto);
        }
        public void Delete(int id)
        {
            _taskManager.Delete(id);
        }
    }
}
