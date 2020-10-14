using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.US.Application
{
   public abstract class BaseApplication
    {
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }
        protected BaseApplication(IConfiguration configuration, ILogger logger)
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
