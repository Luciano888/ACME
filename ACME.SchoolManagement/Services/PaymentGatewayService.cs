using ACME.SchoolManagement.Entities;
using ACME.SchoolManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        /// <summary>
        /// Processes the async payments
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns>
        /// Returns a task with contains a PaymentResult object.
        /// </returns>
        public Task<PaymentResult> ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            paymentRequest.CardToken = SimulazeTokenization(paymentRequest.CardToken);

            var result = new PaymentResult
            {
                Success = true,
                PaymentStatus = "OK",
                PaymentId = Guid.NewGuid().ToString(),
                Message = "Payment processed"
            };

            return Task.FromResult(result);
        }

        /// <summary>
        /// Simulates the tokenization of a card token.
        /// </summary>
        /// <param name="cardToken">The original card token to be tokenized.</param>
        /// <returns>The tokenized card token.</returns>
        private string SimulazeTokenization(string cardTokenParam)
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()); 
        }
    }
}
