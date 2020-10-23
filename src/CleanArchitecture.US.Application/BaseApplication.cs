using CleanArchitecture.US.Common.NLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.US.Application
{
   public abstract class BaseApplication
    {
        public IConfiguration Configuration { get; }
        public ILoggerManager Logger { get; }
        protected BaseApplication(IConfiguration configuration, ILoggerManager logger)
        {
            this.Configuration = configuration;
            this.Logger = logger;
        }
        protected BaseApplication(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    }
}
