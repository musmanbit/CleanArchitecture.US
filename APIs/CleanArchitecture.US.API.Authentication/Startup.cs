using CleanArchitecture.US.Application.Extensions;
using CleanArchitecture.US.Common.Extensions;
using CleanArchitecture.US.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.US.API.Authentication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.RegisterLogging();
            services.RegisterApplicationServices();
            services.RegisterInfrastructureServices();
            services.RegisterAuthenticationService(Configuration);
         
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
         
            app.UseRouting();

            //  app.UseSwaggerMiddleware(this.GetType().Namespace);
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseExceptionMiddleware();
       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
