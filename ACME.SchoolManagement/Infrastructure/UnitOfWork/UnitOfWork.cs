using ACME.SchoolManagement.Entities;
using ACME.SchoolManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ACME.SchoolManagement.Infrastructure.AcmeDbContext;
using ACME.SchoolManagement.Infrastructure.Repositories;

namespace ACME.SchoolManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcmeDbContext _context;
        private IRepository<Student> _studentRepository;
        private IRepository<Course> _courseRepository;
        private IRepository<Inscription> _inscriptionRepository;
        public UnitOfWork(AcmeDbContext context)
        {
            _context = context;
        }
        public IRepository<Student> StudentRepository
        {
            get { return _studentRepository ??= new Repository<Student>(_context); }
        }

        public IRepository<Course> CourseRepository
        {
            get { return _courseRepository ??= new Repository<Course>(_context); }
        }

        public IRepository<Inscription> InscriptionRepository
        {
            get { return _inscriptionRepository ??= new Repository<Inscription>(_context); }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
