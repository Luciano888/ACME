using ACME.SchoolManagement.Entities;
using ACME.SchoolManagement.Interfaces;
using ACME.SchoolManagement.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Tests.UnitTests.Services
{
    public class CourseServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Course>> _courseRepositoryMock;
        private readonly CourseService _courseService;
        public CourseServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>(); 
            _courseRepositoryMock = new Mock<IRepository<Course>>();
            _unitOfWorkMock.Setup(uow => uow.CourseRepository).Returns(_courseRepositoryMock.Object);
            _courseService = new CourseService(_unitOfWorkMock.Object);
        }
        [Fact]
        public void GetCoursesBetweenDates_ShouldReturnCourses()
        {
            var startDate = new DateTime(2024, 2, 1);
            var endDate = new DateTime(2024, 8, 31);
            var courses= new List<Course>
            {
                new Course("Matemática", 100, new DateTime(2024, 3, 1), new DateTime(2024,6,12)),
                new Course("Historia", 150, new DateTime(2024, 5, 1), new DateTime(2024, 7, 1))
            };
            _courseRepositoryMock.Setup(repo => repo.GetAll()).Returns(courses);

            var result = _courseService.GetCoursesBetweenDates(startDate, endDate);
            var expectedCourses = courses.Where(x => x.StartDate >= startDate && x.EndDate <= endDate);
            Assert.Equal(expectedCourses, result);
        }
        [Fact]
        public void RegisterCourse_ShouldADDCourseANDSaveChanges()
        {
            var name = "Biologia";
            var registrationFee = 20;
            var startDate = new DateTime(2024, 2, 1);
            var endDate = new DateTime(2024, 5, 31);
            var newCourse = new Course(name, registrationFee, startDate, endDate);

            _courseRepositoryMock.Setup(repo => repo.Add(It.IsAny<Course>()));
            _unitOfWorkMock.Setup(uow => uow.Save());

            _courseService.RegisterCourse(name, registrationFee, startDate, endDate);
            _courseRepositoryMock.Verify(repo => repo.Add(It.Is<Course>(c => c.Name == name &&
                                                                           c.RegistrationFee == registrationFee &&
                                                                           c.StartDate == startDate &&
                                                                           c.EndDate == endDate)),
                                          Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }

}
