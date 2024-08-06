using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entidad);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Save();
    }
}
