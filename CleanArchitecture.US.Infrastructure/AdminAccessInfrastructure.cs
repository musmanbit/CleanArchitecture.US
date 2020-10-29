#region using directives
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Common.Serilog;
using CleanArchitecture.US.Infrastructure.Interface;
#endregion

namespace CleanArchitecture.US.Infrastructure
{
    public class AdminAccessInfrastructure : AdminAccessInfrastructureBase, IAdminAccessInfrastructure
    {
        public AdminAccessInfrastructure(IConfiguration configuration, ILoggerManager logger) : base(configuration, logger)
        {
        }

    }
}

