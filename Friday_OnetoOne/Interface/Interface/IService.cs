using dtos.dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IService
    {
        public List<Student> GetAllStudents();
        public StudentDTO GetStudentById(int id);
        public void Add(StudentDTO studentDto);
        public bool UpdateById(int id, StudentDTO studentDto);
        public void DeleteById(int id);
    }
}
