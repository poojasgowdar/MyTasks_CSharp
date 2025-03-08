using AutoMapper;
using DTOs.DTO;
using Models.Entities;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskManager(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public List<TaskDto> GetAll()
        {
            var tasks = _taskRepository.GetAll();
            return _mapper.Map<List<TaskDto>>(tasks); 
        }
        public TaskDto GetById(int id)
        {
            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskDto>(task); 
        }
        public void Add(TaskDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            _taskRepository.Add(task); 
        }
        public bool Update(int id, TaskDto taskDto)
        {
            var existingTask = _taskRepository.GetById(id);
            if (existingTask == null)
            {
                return false;
            }
            _mapper.Map(taskDto, existingTask);
            _taskRepository.Update(existingTask);
            return true;
        }
        public void Delete(int id)
        { 
            _taskRepository.Delete(id);
        }
    }

}
