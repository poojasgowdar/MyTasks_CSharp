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
        public List<Student> GetStudents();
        public Student GetById(int id);
        public void Add(Student student);
        public void Update(Student student);
        public void Delete(int id);


    }
}
