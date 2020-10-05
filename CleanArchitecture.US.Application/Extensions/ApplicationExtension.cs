using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Common.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.US.Application.Extensions
{
    public static class ApplicationExtension
    {

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IAdminApplication, AdminApplication>();
            services.AddTransient<IUserApplication, UserApplication>();

            return services;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
     

    }
}

