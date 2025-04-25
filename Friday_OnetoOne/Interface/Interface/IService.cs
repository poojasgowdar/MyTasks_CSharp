using dtos.dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IService
    {
        /// <summary>
        /// Fetches all the Students
        /// </summary>
        /// <returns></returns>
        List<Student> GetAllStudents();

        /// <summary>
        /// Fetches an Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StudentDTO GetStudentById(int id);

        /// <summary>
        ///  Creates an Student 
        /// </summary>
        /// <param name="studentDto"></param>
        void Add(StudentDTO studentDto);

        /// <summary>
        /// Updates an Student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        bool UpdateById(int id, StudentDTO studentDto);

        /// <summary>
        /// Deletes an Student
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);
    }
}
