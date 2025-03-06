using DTOs.dto;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public interface IService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeDTO> GetEmployees();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeDTO GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeDto"></param>
        void Add(EmployeeDTO employeeDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        bool UpdateById(int id, EmployeeDTO employeeDto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);
    }
}
