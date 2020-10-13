#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Application.Interface;

#endregion

namespace CleanArchitecture.US.Application
{
     public class UserApplication:UserApplicationBase, IUserApplication
    {
    #region Constructor
       public UserApplication(IUserInfrastructure userInfrastructure, IConfiguration configuration,
            ILogger <UserApplication> logger) : base(userInfrastructure,configuration, logger)
      {
      }
    #endregion
    }
    }

