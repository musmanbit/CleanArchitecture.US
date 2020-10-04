#region using directives
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CleanArchitecture.US.Domain;
#endregion

namespace CleanArchitecture.US.Application.Interface
{
    public interface IAdminAccessApplication : IBaseApplication<AdminAccess>
    {
        #region Auto Generated
        Task<IList<AdminAccess>> GetListByForeignKeyAdminId(Int32 adminId);
        Task<IList<AdminAccess>> GetListByForeignKeyUserId(Int32 userId);
        #endregion

        #region Custom

        #endregion

    }
}

