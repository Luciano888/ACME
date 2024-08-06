using ACME.SchoolManagement.Entities;
using ACME.SchoolManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Get all the Students
        /// </summary>
        /// <returns>A IEnumerable of Students</returns>
        public IEnumerable<Student> GetAll()
        {
            return _unitOfWork.StudentRepository.GetAll();
        }
        /// <summary>
        /// Get a student by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a object student by ID</returns>
        public Student GetStudentById(int id)
        {
            return _unitOfWork.StudentRepository.GetById(id);
        }
        /// <summary>
        /// Register a new Student with a name and age
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age">The student must be over 18 years</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="age"/> is less than 18. This ensures that only adults can be registered as students.
        /// </exception>
        public void RegisterStudent(string name, int age)
        {
            if(age < 18)
                throw new ArgumentException("The student must be over 18");
            var student = new Student(name, age);
            _unitOfWork.StudentRepository.Add(student);
            _unitOfWork.Save();
        }
    }
}
