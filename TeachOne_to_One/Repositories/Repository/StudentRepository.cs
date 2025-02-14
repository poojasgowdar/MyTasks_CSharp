using Interface.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class StudentRepository:IRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }
        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }
        public void Add(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }
        public void Update(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var students = _context.Students.Find(id);
            if (students != null)
            {
                _context.Remove(students);
                _context.SaveChanges();
            }
        }
    }
}
