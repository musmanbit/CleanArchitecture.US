#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Application.Interface;

#endregion

namespace CleanArchitecture.US.Application
{
    public class AdminAccessApplication : AdminAccessApplicationBase, IAdminAccessApplication
    {
        #region Constructor
        public AdminAccessApplication(IAdminAccessInfrastructure adminaccessInfrastructure, IConfiguration configuration,
             ILogger<AdminAccessApplication> logger) : base(adminaccessInfrastructure, configuration, logger)
        {
        }
        #endregion
    }
}

