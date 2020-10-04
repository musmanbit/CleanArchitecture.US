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
     public class UserInfrastructure:UserInfrastructureBase, IUserInfrastructure
    {
      public UserInfrastructure(IConfiguration configuration, ILogger<User> logger):base(configuration, logger){
}

    }
    }

