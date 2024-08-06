using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Entities
{
    public class PaymentResult
    {
        public bool Success { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public string Message { get; set; }
    }

    public class PaymentRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; } // Solo para simular 
        public string CardToken { get; set; }
    }

}
