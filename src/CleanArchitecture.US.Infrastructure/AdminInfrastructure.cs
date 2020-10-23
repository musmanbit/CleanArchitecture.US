#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Common.NLog;
#endregion

namespace CleanArchitecture.US.Infrastructure
{
     public class AdminInfrastructure:AdminInfrastructureBase, IAdminInfrastructure
    {
      public AdminInfrastructure(IConfiguration configuration, ILoggerManager logger):base(configuration, logger){
}

    }
    }

