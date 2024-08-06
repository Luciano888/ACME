using ACME.SchoolManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Infrastructure
{

        public class AcmeDbContext : DbContext
        {
            public AcmeDbContext(DbContextOptions<AcmeDbContext> options) : base(options)
            {
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Inscription> Inscriptions { get; set; }
        }
    }
