using ACME.SchoolManagement.Infrastructure;
using ACME.SchoolManagement.Infrastructure.Repositories;
using ACME.SchoolManagement.Infrastructure.UnitOfWork;
using ACME.SchoolManagement.Interfaces;
using ACME.SchoolManagement.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ACME.SchoolManagement
{
    internal class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            // Connection example
            //services.AddDbContext<AcmeDbContext>(options =>
            //    options.UseSqlite("Data Source=products.db"));

            services.AddScoped<IUnitOfWork, UnitOfWork> ();
            //services.AddScoped<IPaymentGateway, PaymentGateway> ();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IInscriptionService, InscriptionService>();

        }
    }
}
