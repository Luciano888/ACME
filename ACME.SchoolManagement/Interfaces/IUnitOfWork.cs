using ACME.SchoolManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Course> CourseRepository { get; }
        IRepository<Inscription> InscriptionRepository { get; }
        void Save();
    }
}
