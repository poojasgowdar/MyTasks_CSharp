using Dto.dtos;
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
        public void Add(StudentDTO studentDto);
        public bool Update(int id,StudentDTO studentDto);
        public void Delete(int id);
    }
}
