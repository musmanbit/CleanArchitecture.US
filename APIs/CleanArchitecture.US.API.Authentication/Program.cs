using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CleanArchitecture.US.Common.Extensions;

namespace CleanArchitecture.US.API.Authentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureNlogLogging()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
