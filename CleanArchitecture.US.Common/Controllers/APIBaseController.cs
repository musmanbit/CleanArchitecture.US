using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.US.Common.Controllers
{
    /// <summary>
    /// Base class for all api controllers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class APIBaseController : ControllerBase
    {

        #region Properties
        public IConfiguration Configuration { get; }
        
        protected ILogger Logger { get; }
        protected bool UseDefaultLanguage { get; }
        #endregion
        protected APIBaseController(IConfiguration configuration, ILogger logger) {
            this.Configuration = configuration;
            this.Logger = logger;
        }

        
    }
}
