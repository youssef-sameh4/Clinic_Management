using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagement.Application
{
    public static class ModelAppDependance
    {
        public static IServiceCollection AddAppDependance(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ModelAppDependance).Assembly));

            services.AddAutoMapper(cfg => { }, typeof(ModelAppDependance).Assembly);
            return services;
        }
    }
}