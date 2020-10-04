#region using directives
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Infrastructure.Interface;
#endregion

namespace CleanArchitecture.US.Infrastructure
{
     public class AdminInfrastructure:AdminInfrastructureBase, IAdminInfrastructure
    {
      public AdminInfrastructure(IConfiguration configuration, ILogger<Admin> logger):base(configuration, logger){
}

    }
    }

