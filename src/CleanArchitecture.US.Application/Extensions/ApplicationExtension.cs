using CleanArchitecture.US.Application.Interface;
using Microsoft.Extensions.DependencyInjection;

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
     
     

    }
}

