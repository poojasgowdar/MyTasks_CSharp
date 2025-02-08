using Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IService
    {
        public List<StudentDTO> GetAllStudents();
        public StudentDTO GetStudentById(int id);
        public void AddStudent(StudentDTO studentDto);
        public bool UpdateStudent(int id,StudentDTO studentDto);
        public void DeleteStudent(int id);
    }
}
