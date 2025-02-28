using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interface
{
    public interface IRepository
    {
         List<Student> GetStudents();
         Student GetById(int id);
         void Add(Student student);
         void Update(Student student);
         void Delete(int id);


    }
}
