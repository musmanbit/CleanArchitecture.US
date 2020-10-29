#region using directives

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Application.Interface;
using System.Threading.Tasks;
using CleanArchitecture.US.Domain;
using System.Transactions;
using CleanArchitecture.US.Infrastructure;
using CleanArchitecture.US.Common.Serilog;

#endregion

namespace CleanArchitecture.US.Application
{
    public class AdminApplication : AdminApplicationBase, IAdminApplication
    {
        private IUserApplication _userApplication { get; }


        #region Constructor
        public AdminApplication(IAdminInfrastructure adminInfrastructure, IUserApplication userApplication, IConfiguration configuration,
             ILoggerManager logger) : base(adminInfrastructure, configuration, logger)
        {
            _userApplication = userApplication;
        }

        public async Task<bool> SaveAdminUser(Admin admin, User user)
        {
            var result = false;

            using (
                   var scope = new TransactionScope(TransactionScopeOption.Required,
                       TransactionScopeAsyncFlowOption.Enabled))
            {

                var adminResponse = await Save(admin);
                user.AdminId = adminResponse.AdminId;
                var userresponse = await _userApplication.Save(user,false);
                //int i = 5;
                //int d = 0;
                //var res = i / d;
                result = true;
                scope.Complete();

            }

            return result;
        }
        #endregion
    }
}

