using CleanArchitecture.US.Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.US.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IAdminInfrastructure, AdminInfrastructure>();
            services.AddTransient<IUserInfrastructure, UserInfrastructure>();

            return services;
        }
        
    }
}
