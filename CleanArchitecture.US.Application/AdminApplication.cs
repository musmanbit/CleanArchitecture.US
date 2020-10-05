#region using directives
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Common;
using CleanArchitecture.US.Infrastructure;
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

