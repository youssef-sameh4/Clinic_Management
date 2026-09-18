using ClinicManagement.Application.Interfaces;
using ClinicManagement.Infrastructure.Interfaces;
using ClinicManagement.Infrastructure.Repositories;
using ClinicManagement.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure
{
    public static class ModelInfrustrctureDependance
    {
        public static IServiceCollection AddInfrustrctureDependance(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
