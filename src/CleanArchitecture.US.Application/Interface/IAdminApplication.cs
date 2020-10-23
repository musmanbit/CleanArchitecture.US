#region using directives

using CleanArchitecture.US.Domain;
using System.Threading.Tasks;
#endregion

namespace CleanArchitecture.US.Application.Interface
{
    public interface IAdminApplication : IBaseApplication<Admin>
    {
        #region Auto Generated
        #endregion

        #region Custom
        Task<bool> SaveAdminUser(Admin admin, User user);
        #endregion

    }
}

