using Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class StudentRepository:IRepository<Student>
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.Include(s => s.Course).ToList();
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
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
