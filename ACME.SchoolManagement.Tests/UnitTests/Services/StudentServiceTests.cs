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
    public class StudentServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Student>> _studentRepositoryMock;
        private readonly StudentService _serviceUnderTest;

        public StudentServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _studentRepositoryMock = new Mock<IRepository<Student>>();
            _unitOfWorkMock.Setup(uow => uow.StudentRepository).Returns(_studentRepositoryMock.Object);
            _serviceUnderTest = new StudentService(_unitOfWorkMock.Object);
        }
        [Fact]
        public void GetAll_ShouldReturnAllStudents()
        {
            // Arrange
            var expectedStudents = new List<Student>
            {
                new Student("Paula Singh", 24),
                new Student("Maximiliano Server", 31)
            };
            _studentRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedStudents);

            // Act
            var allStudents = _serviceUnderTest.GetAll();

            // Assert
            Assert.Equal(expectedStudents, allStudents);
        }

        [Fact]
        public void GetStudentById_ShouldReturnStudent_WhenStudentExists()
        {
            // Arrange
            var studentExpected = new Student("Paula Singh", 22);
            _studentRepositoryMock.Setup(repo => repo.GetById(1)).Returns(studentExpected);

            // Act
            var actualStudent = _serviceUnderTest.GetStudentById(1);

            // Assert
            Assert.Equal(studentExpected, actualStudent);
        }

        [Fact]
        public void GetStudentById_ShouldReturnNull_WhenStudentDoesNotExist()
        {
            // Arrange
            _studentRepositoryMock.Setup(repo => repo.GetById(1)).Returns((Student)null);

            // Act
            var student = _serviceUnderTest.GetStudentById(1);

            // Assert
            Assert.Null(student);
        }

        [Fact]
        public void RegisterStudent_ShouldThrowArgumentException_WhenAgeIsUnderage()
        {
            // Arrange
            var name = "Robert Gallatti";
            var age = 16;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _serviceUnderTest.RegisterStudent(name, age));
            Assert.Equal("The student must be over 18", exception.Message);
        }

        [Fact]
        public void RegisterStudent_ShouldAddStudentAndCallSave_WhenAgeIsValid()
        {
            // Arrange
            var name = "Lucas Rodriguez";
            var age = 20;
            var newStudent = new Student(name, age);

            _studentRepositoryMock.Setup(repo => repo.Add(It.IsAny<Student>()));
            _unitOfWorkMock.Setup(uow => uow.Save());

            // Act
            _serviceUnderTest.RegisterStudent(name, age);

            // Assert
            _studentRepositoryMock.Verify(repo => repo.Add(It.Is<Student>(s => s.Name == name && s.Age == age)), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }
}
