using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public Payment(int id, string transactionId, DateTime creationDate, string status) { 
            Id = id;
            TransactionId = transactionId;
            CreationDate = creationDate;
            Status = status;
        }
    }
}
