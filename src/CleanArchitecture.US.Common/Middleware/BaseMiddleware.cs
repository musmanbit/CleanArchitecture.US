using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.US.Common.Middleware
{
    public abstract class BaseMiddleware
    {
        #region Properties and Data Members
        protected RequestDelegate Next { get; }
        public IConfiguration Configuration { get; }
        protected ILogger Logger { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// BaseMiddleware .
        /// </summary>
        /// <param name="next"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        protected BaseMiddleware(RequestDelegate next, IConfiguration configuration, ILogger logger)
        {
            this.Next = next;
            this.Configuration = configuration;
            this.Logger = logger;
        }
        #endregion

    }
}
