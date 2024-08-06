using ACME.SchoolManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Interfaces
{
    public interface IStudentService
    {
        void RegisterStudent(string name, int age);
        Student GetStudentById(int id);
        IEnumerable<Student> GetAll();
    }
}
