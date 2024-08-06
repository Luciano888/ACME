using ACME.SchoolManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Interfaces
{
    public interface IInscriptionService
    {
        public Task<PaymentResult> ContractCourse(int studentId, int courseId, DateTime dateInscription);
    }
}
