using AutoMapper;
using Dto.dtos;
using Interfaces.Interface;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class StudentService:IService
    {
        private readonly IRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public List<StudentDTO> GetAllStudents()
        {
            var students = _studentRepository.GetStudents();
            return _mapper.Map<List<StudentDTO>>(students);
        }
        public StudentDTO GetStudentById(int id)
        {
            var students = _studentRepository.GetById(id);
            return _mapper.Map<StudentDTO> (students);
        }
        public void Add(StudentDTO studentDto)
        {
            var student=_mapper.Map<Student>(studentDto);
            _studentRepository.Add(student);
        }
        public bool Update(int id, StudentDTO studentDto)
        {
            var existingStudent = _studentRepository.GetById(id);
            if (existingStudent == null)
            {
                return false;
            }
            _mapper.Map(studentDto, existingStudent);
            _studentRepository.Update(existingStudent);
            return true;

        }
        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}
