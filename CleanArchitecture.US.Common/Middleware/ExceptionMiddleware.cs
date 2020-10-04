using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;


namespace CleanArchitecture.US.Common.Middleware
{
    /// <summary>
    /// HeaderValueMiddleware is used to parse header values before requested controller has been invoked.
    /// </summary>
    public class ExceptionMiddleware : BaseMiddleware
    {
        #region Properties and Data Members

        #endregion

        #region Constructor
        /// <summary>
        /// ErrorHandlingMiddleware initializes class object.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<ExceptionMiddleware> logger) : base(next, configuration, logger)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Invoke method is called when middleware has been called.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="headerValue"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.Next(context);
            }
            catch (Exception ex)
            {
                await this.HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// HandleExceptionAsync creates response in case of exception.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <param name="headerValue"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is EntryPointNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (exception is AccessViolationException)
            {
                code = HttpStatusCode.Forbidden;
            }
            else if (exception is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
            }
         

            var result = JsonConvert.SerializeObject(new { error = exception.Message });

            context.Response.ContentType = Constant.JsonContentType;
            context.Response.StatusCode = (int)code;

           //todo base.Logger?.LogExeception(exception, headerValue);

            return context.Response.WriteAsync(result);
        }
        #endregion
    }
}