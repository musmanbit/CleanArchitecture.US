using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NUnit.Framework;


namespace CleanArchitecture.US.API.Authentication.IntegrationTest.Fixtures
{
    public abstract class IntegrationTest //: OneTimeSetUpAttribute
    {
        //protected readonly HttpClient Client;
        //private  readonly string _baseUrl = "https://localhost:44392";

        //protected IntegrationTest()
        //{
        //    var appFactory = new WebApplicationFactory<Startup>();


        //    Client = appFactory.CreateClient();
        //    Client.BaseAddress = new Uri(_baseUrl);
        //}

        protected readonly ApiWebApplicationFactory Factory;
        protected readonly HttpClient Client;
        protected readonly IConfiguration Configuration;
        private readonly string _baseUrl = "https://localhost:44392";
        public IntegrationTest()
        {
            Factory = new ApiWebApplicationFactory();
            Client = Factory.CreateClient();
            Client.BaseAddress = new Uri(_baseUrl);

            Configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

        }
    }

}
