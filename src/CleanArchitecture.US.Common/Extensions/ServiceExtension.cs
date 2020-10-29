using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using CleanArchitecture.US.Common.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Microsoft.Extensions.Hosting;
using CleanArchitecture.US.Common.NLog;
using Serilog;

namespace CleanArchitecture.US.Common.Extensions
{
    /// <summary>
    /// ServiceExtensions class provides implementation for extension methods.
    /// </summary>
    public static class ServiceExtension
    {
        private const string SwaggerPath = "/swagger/v1/swagger.json";

       
        public static IServiceCollection RegisterAuthenticationService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//configuration["Jwt:AuthKey"];// 
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(cfg =>
             {
                 cfg.RequireHttpsMetadata = false;
                 cfg.SaveToken = true;
                 cfg.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidIssuer = configuration["Jwt:Issuer"],
                     ValidAudience = configuration["Jwt:Audience"],
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Encryptionkey"])),
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     
                 };
                 cfg.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }

                 };
             });

            return services;
        }

        public static IServiceCollection RegisterPolicies(this IServiceCollection services)
        {

            //var applicationClaim = new ApplicationClaim();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("defaultpolicy", b =>
                {
                    b.RequireAuthenticatedUser();
                });
            });

            return services;
        }


        /// <summary>
        /// UseCorsMiddleware registers UseCors.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder app)
        {
            return app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
        }

        /// <summary>
        /// UseTokenValidatorMiddleware registers Token Parser
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseTokenValidatorMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TokenValidatorMiddleware>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
        /// <summary>
        /// Registers Swagger Middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app, string apiName)
        {
            app.UseSwagger();
            return app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ServiceExtension.SwaggerPath, apiName);                
            });
        }

        /// <summary>
        /// registers Swagger components.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiName"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSwagger(this IServiceCollection services, string apiName, string description)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = apiName,
                    Description = description
                    
                });
            });
            return services;
        }

        public static IHostBuilder ConfigureNlogLogging(this IHostBuilder hostBuilder)
        {
            //NLog
            hostBuilder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Error);
            }).UseNLog();
            
            //hostBuilder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
            //    .ReadFrom.Configuration(hostingContext.Configuration));


            return hostBuilder;
        }
        public static IHostBuilder ConfigureSeriLogLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog();
            return hostBuilder;
        }



        public static IServiceCollection RegisterNlogLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            return services;
        }
        public static IServiceCollection RegisterSeriLogLogging(this IServiceCollection services)
        {
            services.AddSingleton<Serilog.ILoggerManager, Serilog.LoggerManager>();
            return services;
        }
    }
}