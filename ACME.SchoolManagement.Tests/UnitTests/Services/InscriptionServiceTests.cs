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
    public class InscriptionServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Course>> _courseRepositoryMock;
        private readonly Mock<IRepository<Student>> _studentRepositoryMock;
        private readonly Mock<IRepository<Inscription>> _inscriptionRepositoryMock;
        private readonly Mock<IPaymentGatewayService> _paymentGatewayServiceMock;
        private readonly InscriptionService _inscriptionService;
        public InscriptionServiceTests() {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _courseRepositoryMock = new Mock<IRepository<Course>>();
            _studentRepositoryMock = new Mock<IRepository<Student>>();
            _inscriptionRepositoryMock = new Mock<IRepository<Inscription>>();
            _paymentGatewayServiceMock = new Mock<IPaymentGatewayService>();

            _unitOfWorkMock.Setup(uow => uow.CourseRepository).Returns(_courseRepositoryMock.Object);
            _unitOfWorkMock.Setup(uow => uow.StudentRepository).Returns(_studentRepositoryMock.Object);
            _unitOfWorkMock.Setup(uow => uow.InscriptionRepository).Returns(_inscriptionRepositoryMock.Object);

            _inscriptionService = new InscriptionService(_unitOfWorkMock.Object, _paymentGatewayServiceMock.Object);
        }

        /*[Fact]
        public void AddInscription_ValidCourse_Exceptin()
        {
            // Arrange
            var studentId = 1;
            var courseId = 2;
            var inscriptionDate = new DateTime(2024, 8, 1);

            var course = new Course("Matemática", 120, new DateTime(2024, 9, 1), new DateTime(2024, 12, 15));
            var student = new Student("Paula Singh", 24);

            _courseRepositoryMock.Setup(repo => repo.GetById(courseId)).Returns(course);
            _studentRepositoryMock.Setup(repo => repo.GetById(studentId)).Returns(student);
            _inscriptionRepositoryMock.Setup(repo => repo.Add(It.IsAny<Inscription>()));
            _unitOfWorkMock.Setup(uow => uow.Save()); 

            // Act
            _inscriptionService.ContractCourse(studentId, courseId, inscriptionDate);

            // Assert
            _inscriptionRepositoryMock.Verify(repo => repo.Add(It.Is<Inscription>(i =>
                i.CourseId == courseId &&
                i.StudentId == studentId &&
                i.InscriptionDate == inscriptionDate
            )), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }*/

        [Fact]
        public async Task ContractCourseAsync_SuccessfulPayment()
        {
            var course = new Course(1, 15);
            var student = new Student(1,"Nombre de prueba", 20);
            _courseRepositoryMock.Setup(x => x.GetById(1)).Returns(course);
            _studentRepositoryMock.Setup(x => x.GetById(1)).Returns(student);
            _paymentGatewayServiceMock.Setup(x => x.ProcessPaymentAsync(It.IsAny<PaymentRequest>())).ReturnsAsync(new PaymentResult { Success = true });

            var result = await _inscriptionService.ContractCourse(1, 1, DateTime.Now);
            Assert.True(result.Success);
            Assert.Equal("Inscription completed", result.Message);
        }

        [Fact]
        public async Task ContractCourseAsync_SuccessfulPayment_PaymentNotRequired()
        {
            var course = new Course(1, 0);
            var student = new Student(1, "Nombre de prueba", 20);
            _courseRepositoryMock.Setup(x => x.GetById(1)).Returns(course);
            _studentRepositoryMock.Setup(x => x.GetById(1)).Returns(student);

            var result = await _inscriptionService.ContractCourse(1, 1, DateTime.Now);
            Assert.True(result.Success);
            Assert.Equal("Inscription completed", result.Message);
        }

        [Fact]
        public async Task ContractCourseAsync_FailedPayment()
        {
            var course = new Course(1, 15);
            var student = new Student(1, "Nombre de prueba", 20);
            _courseRepositoryMock.Setup(x => x.GetById(1)).Returns(course);
            _studentRepositoryMock.Setup(x => x.GetById(1)).Returns(student);
            _paymentGatewayServiceMock.Setup(x => x.ProcessPaymentAsync(It.IsAny<PaymentRequest>())).ReturnsAsync(new PaymentResult { Success = false, Message = "Payment failed" });

            var result = await _inscriptionService.ContractCourse(1, 1, DateTime.Now);
            Assert.False(result.Success);
            Assert.Equal("Payment failed", result.Message);
        }



    }
}
