using AutoMapper;
using Dto.Dtos;
using Interfaces.Interface;
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
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> productRepository, IMapper mapper)
        {
            _studentRepository = productRepository;
            _mapper = mapper;
        }
        public List<StudentDTO> GetAllStudents()
        {
            var students = _studentRepository.GetAll();
            return _mapper.Map<List<StudentDTO>>(students);
        }
        public StudentDTO GetStudentById(int id)
        {
            var students = _studentRepository.GetById(id);
            return _mapper.Map<StudentDTO>(students);
        }   
        public void AddStudent(StudentDTO studentDto)
        {
            var student=_mapper.Map<Student>(studentDto);
            _studentRepository.Add(student);
        }
        public bool UpdateStudent(int id,StudentDTO studentDto)
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
        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}
