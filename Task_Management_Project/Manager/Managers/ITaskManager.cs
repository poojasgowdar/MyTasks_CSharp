using DTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Managers
{
    public interface ITaskManager
    {
        List<TaskDto> GetAll();
        TaskDto GetById(int id);
        void Add(TaskDto taskDto);
        bool Update(int id, TaskDto taskDto);
        void Delete(int id);
    }
}
