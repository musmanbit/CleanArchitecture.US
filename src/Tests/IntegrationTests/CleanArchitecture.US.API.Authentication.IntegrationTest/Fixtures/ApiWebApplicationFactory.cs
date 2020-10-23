using CleanArchitecture.US.Application;
using CleanArchitecture.US.Application.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.US.API.Authentication.IntegrationTest.Fixtures
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Authentication.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                var integrationConfig = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

                config.AddConfiguration(integrationConfig);
            });

            // is called after the `ConfigureServices` from the Startup
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IAdminApplication, AdminApplication>();
            });
        }
    }
}
