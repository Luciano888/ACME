using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Course(string name, decimal registrationFee, DateTime startDate, DateTime endDate) { 
            Name = name;
            RegistrationFee = registrationFee;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Course(int id, decimal registrationFee)
        {
            Id = id;
            RegistrationFee = registrationFee;
        }
    }
}
