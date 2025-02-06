
using MVC_New_Project.Models;

namespace MVC_New_Project.Interfaces
{
    public interface IRepository<T> where T : class
    {   
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void UpdateById(int id, T entity);
        public void DeleteById(int id);
    }
}
