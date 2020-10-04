#region using directives
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CleanArchitecture.US.Domain;
#endregion

namespace CleanArchitecture.US.Application.Interface
{
     public interface IUserApplication : IBaseApplication<User>
    {
      #region Auto Generated
      Task<IList<User>> GetListByForeignKeyAdminId(Int32 adminId);
      #endregion

      #region Custom

      #endregion

    }
    }

