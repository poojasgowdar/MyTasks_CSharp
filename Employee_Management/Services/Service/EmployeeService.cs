using AutoMapper;
using DTOs.dto;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using Models.Entities;
using Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class EmployeeService:IService
    {
        private readonly IRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(IRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            _logger.LogInformation("Fetching all employees from the database");
            var employees = _employeeRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }
        public EmployeeDTO GetById(int id)
        {
            _logger.LogInformation("Fetching employee with ID: {Id}", id);
            var employees = _employeeRepository.GetById(id);
            if (employees == null)
            {
                _logger.LogWarning("Employee with ID {id} not found.",id);
                return null;
            }
            return _mapper.Map<EmployeeDTO>(employees);
        }
        public void Add(EmployeeDTO employeeDto)
        {
            _logger.LogInformation("Adding a new Employee: {@employeeDto}", employeeDto);
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Add(employee);
            _logger.LogInformation("Employee Added Successfully");
        }
        public bool UpdateById(int id, EmployeeDTO employeeDto)
        {
            _logger.LogInformation("Updating Employee with ID:{Id}", id);
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee != null)
            {
                _mapper.Map(employeeDto, existingEmployee);
                _employeeRepository.Update(existingEmployee);
                _logger.LogInformation("Employee with ID {id} updated successfully,",id);
                return true;
            }
            _logger.LogWarning("Employee with ID {id} not found. Update Failed.", id);
            return false;
        }
        public void DeleteById(int id)
        {
            _logger.LogInformation("Deleting Employee with ID {id}.", id);
            _employeeRepository.Delete(id);
            _logger.LogInformation("Employee with ID {id} deleted Successfully.", id);
        }
        
    }
}
