using CleanArchitecture.US.Infrastructure.Interface;
using Microsoft.Extensions.DependencyInjection;

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
