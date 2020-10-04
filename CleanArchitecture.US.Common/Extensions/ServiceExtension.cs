using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(cfg =>
             {
                 cfg.RequireHttpsMetadata = false;
                 cfg.SaveToken = true;
                 cfg.TokenValidationParameters = new TokenValidationParameters()
                 {
                     //ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Encryptionkey"])),
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidIssuer = configuration["Jwt:Issuer"],
                     //ValidAudience = Configuration["Jwt:Audience"],
                     //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                 };
                 cfg.Events = new JwtBearerEvents
                 {
                     OnTokenValidated = async ctx =>
                     {
                         //Stopwatch watch = new Stopwatch();
                         //watch.Start();

                         var currentUserRoles = ctx.Principal.Claims.Where(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).ToList();

                         try
                         {
                             if (currentUserRoles != null && currentUserRoles.Count > 0)
                             {
                                 var _issuer = configuration["Jwt:Issuer"].ToString();
                                 var _originalIssuer = configuration["Jwt:Issuer"].ToString();


                                 HashSet<string> userClaims = new HashSet<string>();

                                 //get all claims with role object here.
                                 //Dictionary<string, HashSet<string>> roleClaimsDictionary = await roleClaimCache.GetBulk("RoleClaims");

                                 //foreach (var role in currentUserRoles)
                                 //{
                                 //    if (roleClaimsDictionary.ContainsKey(role.Value))
                                 //    {
                                 //        userClaims.UnionWith(roleClaimsDictionary[role.Value]);
                                 //    }
                                 //}

                                 var newclaims = new List<Claim>();
                                 foreach (var userClaim in userClaims)
                                 {
                                     newclaims.Add(new Claim(userClaim, string.Empty, ClaimValueTypes.String, issuer: _issuer, originalIssuer: _originalIssuer, subject: ctx.Principal.Identities.First()));
                                 }

                                 var appIdentity = new ClaimsIdentity(newclaims);

                                 ctx.Principal.AddIdentity(appIdentity);
                                                                  
                             }
                         }
                         catch (Exception ex)
                         {
                             throw new Exception("[Failed in OnTokenValidated for RegisterJWTAuthenticationService] - ex.Message:[" + ex.Message + "] - " + ex.StackTrace);
                         }
                     }
                 };
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