using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.US.Application
{
   public abstract class BaseApplication
    {
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }
        public BaseApplication(IConfiguration configuration, ILogger logger)
        {
            this.Configuration = configuration;
            this.Logger = logger;

           // this.Logger?.LogEnterConstructor(this.GetType());
        }
        public BaseApplication(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    }
}
