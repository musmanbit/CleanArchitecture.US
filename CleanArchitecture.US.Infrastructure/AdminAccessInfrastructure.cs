#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Infrastructure.Interface;
#endregion

namespace CleanArchitecture.US.Infrastructure
{
     public class AdminAccessInfrastructure:AdminAccessInfrastructureBase, IAdminAccessInfrastructure
    {
      public AdminAccessInfrastructure(IConfiguration configuration, ILogger<AdminAccess> logger):base(configuration, logger){
}

    }
    }

