using ACME.SchoolManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ACME.SchoolManagement.Infrastructure.AcmeDbContext;

namespace ACME.SchoolManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AcmeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AcmeDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            return entity;
        }

        public void Add(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
