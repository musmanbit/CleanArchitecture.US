#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Common.NLog;

#endregion

namespace CleanArchitecture.US.Application
{
     public class UserApplication:UserApplicationBase, IUserApplication
    {
    #region Constructor
       public UserApplication(IUserInfrastructure userInfrastructure, IConfiguration configuration,
            ILoggerManager logger) : base(userInfrastructure,configuration, logger)
      {
      }
    #endregion
    }
    }

