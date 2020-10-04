#region using directives
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.US.Domain;
#endregion

namespace CleanArchitecture.US.Infrastructure.Interface
{
    public interface IAdminAccessInfrastructure : IBaseInfrastructure<AdminAccess>
    {
        #region Auto Generated
        Task<IList<AdminAccess>> GetListByForeignKeyAdminId(Int32 adminId);
        Task<IList<AdminAccess>> GetListByForeignKeyUserId(Int32 userId);
        #endregion

        #region Custom

        #endregion

    }
}

