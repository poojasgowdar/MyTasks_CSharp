using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IRepository
    {
        /// <summary>
        /// Fetches all the students
        /// </summary>
        /// <returns></returns>
        List<Student> GetStudents();

        /// <summary>
        /// Fetches an Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetById(int id);

        /// <summary>
        /// Creates an new Student
        /// </summary>
        /// <param name="student"></param>
        void Add(Student student);

        /// <summary>
        /// Updates an Existing Student
        /// </summary>
        /// <param name="student"></param>
        void Update(Student student);

        /// <summary>
        /// Deletes an Student
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
