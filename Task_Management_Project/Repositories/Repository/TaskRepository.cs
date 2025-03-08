using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class TaskRepository:ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }
        public TaskItem GetById(int id)
        {
            return _context.TaskItems.FirstOrDefault(t => t.Id == id);
        }
        public void Add(TaskItem task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
        public void Update(TaskItem task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
