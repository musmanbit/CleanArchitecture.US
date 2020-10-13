using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using CleanArchitecture.US.Common.Middleware;
using Swashbuckle.AspNetCore.Swagger;

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
        /// UseSwaggerMiddleware registers Swagger Middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app, string applicationName)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            return app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ServiceExtension.SwaggerPath, applicationName);
            });
        }

        /// <summary>
        /// RegisterSwagger registers Swagger components.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="applicationName"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSwagger(this IServiceCollection services, string applicationName)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = applicationName, Version = "v1" });
            });

            return services;
        }
    }
}