using ACME.SchoolManagement.Entities;
using ACME.SchoolManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Services
{
    public class InscriptionService : IInscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentGatewayService _paymentGatewayService;

        public InscriptionService(IUnitOfWork unitOfWork, IPaymentGatewayService paymentGatewayService)
        {
            _unitOfWork = unitOfWork;
            _paymentGatewayService = paymentGatewayService;
        }
        /// <summary>
        /// Registers a student for a course and processes the payment if required.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="dateInscription"></param>
        /// <returns>
        /// A async task that contains a object indicating if the payment was successfully
        /// </returns>
        public async Task<PaymentResult> ContractCourse(int studentId, int courseId, DateTime dateInscription)
        {
            var course = _unitOfWork.CourseRepository.GetById(courseId);
            var student = _unitOfWork.StudentRepository.GetById(studentId);
            // TO DO: Validation existencia
            if(course.RegistrationFee > 0)
            {
                var paymentRequest = new PaymentRequest
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    Amount = course.RegistrationFee,
                    CardNumber = "222222222222222222222222" // Only for the PoC
                };
                var payment = await _paymentGatewayService.ProcessPaymentAsync(paymentRequest);
                if (!payment.Success)
                {
                    return payment;
                }
            }
            var inscription = new Inscription(courseId, studentId, dateInscription);
            _unitOfWork.InscriptionRepository.Add(inscription);
            _unitOfWork.Save();

            return new PaymentResult
            {
                Success = true,
                PaymentId = "1",
                Message = "Inscription completed"
            };
        }
    }
}
