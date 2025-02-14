using AutoMapper;
using dtos.dto;
using Interface.Interface;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class Studentservice : IService
    {
        private readonly IRepository _studentRepository;
        private readonly IMapper _mapper;
        public Studentservice(IRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public List<Student> GetAllStudents()
        {
            var students = _studentRepository.GetStudents();
            return students;
        }
        public StudentDTO GetStudentById(int id)
        {
            var students = _studentRepository.GetById(id);
            return _mapper.Map<StudentDTO>(students);
        }
        public void Add(StudentDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            _studentRepository.Add(student);
        }
        public bool UpdateById(int id, StudentDTO studentDto)
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
        public void DeleteById(int id)
        {
            _studentRepository.Delete(id);
        }

    }
}
