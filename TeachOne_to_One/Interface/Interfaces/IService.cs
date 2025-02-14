using Dtos.dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IService
    {
        public List<Student> GetStudents();
        public Student GetById(int id);
        public void Add(StudentDTO studentDto);
        public bool Update(int id,StudentDTO studentDto);
        public void Delete(int id);
    }
}
