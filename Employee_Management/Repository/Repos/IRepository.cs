using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAllEmployees();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emp"></param>
        void Add(Employee emp);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emp"></param>
        void Update(Employee emp);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
