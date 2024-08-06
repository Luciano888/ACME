using ACME.SchoolManagement.Entities;
using ACME.SchoolManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;   
        }
        /// <summary>
        /// Returns all courses with a specified date range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>An Enumerable collection of <see cref="Course"/> objects</returns>
        public IEnumerable<Course> GetCoursesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _unitOfWork.CourseRepository.GetAll()
                    .Where(x => x.StartDate >= startDate && x.EndDate <= endDate)
                    .ToList();
        }
        /// <summary>
        /// Register a course with a specified params
        /// </summary>
        /// <param name="name"></param>
        /// <param name="registrationFee"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void RegisterCourse(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
        {
            var course = new Course ( name, registrationFee, startDate, endDate );
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.Save();
        }
    }
}
