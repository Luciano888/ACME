using ACME.SchoolManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Interfaces
{
    public interface IPaymentGatewayService
    {
        //PaymentResult GeneratePay(decimal amount, string coin, string cardNumber, string ccv, string dateExpiration, string nameTitular);
        Task<PaymentResult> ProcessPaymentAsync(PaymentRequest paymentRequest);
    }
}
