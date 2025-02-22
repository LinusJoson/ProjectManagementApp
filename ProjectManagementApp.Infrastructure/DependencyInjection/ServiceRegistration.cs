using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementApp.Core.Interfaces;
using ProjectManagementApp.Core.Services;
using ProjectManagementApp.Infrastructure.Data;
using ProjectManagementApp.Infrastructure.Repositories;

namespace ProjectManagementApp.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string connectionstring)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionstring));

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
