#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Common.NLog;

#endregion

namespace CleanArchitecture.US.Application
{
    public class AdminAccessApplication : AdminAccessApplicationBase, IAdminAccessApplication
    {
        #region Constructor
        public AdminAccessApplication(IAdminAccessInfrastructure adminaccessInfrastructure, IConfiguration configuration,
             ILoggerManager logger) : base(adminaccessInfrastructure, configuration, logger)
        {
        }
        #endregion
    }
}

