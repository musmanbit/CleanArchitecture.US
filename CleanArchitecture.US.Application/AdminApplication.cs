#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Application.Interface;

#endregion

namespace CleanArchitecture.US.Application
{
     public class AdminApplication:AdminApplicationBase, IAdminApplication
    {
    #region Constructor
       public AdminApplication(IAdminInfrastructure adminInfrastructure, IConfiguration configuration,
            ILogger<AdminApplication> logger) : base(adminInfrastructure,configuration, logger)
      {
      }
    #endregion
    }
    }

