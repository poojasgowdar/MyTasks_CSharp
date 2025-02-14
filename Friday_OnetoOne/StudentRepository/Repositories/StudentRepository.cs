using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : IRepository
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
            return _context.Students.Include(s => s.Course).FirstOrDefault(s => s.Id == id);
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var students = _context.Students.Find(id);
            if (students != null)
            {
                _context.Students.Remove(students);
                _context.SaveChanges();
            }
        }
    }
}
