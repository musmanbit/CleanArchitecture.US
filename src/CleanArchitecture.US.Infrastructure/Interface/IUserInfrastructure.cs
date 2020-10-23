#region using directives
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.US.Domain;
#endregion

namespace CleanArchitecture.US.Infrastructure.Interface
{
     public interface IUserInfrastructure: IBaseInfrastructure<User>
    {
      #region Auto Generated
      Task<IList<User>> GetListByForeignKeyAdminId(Int32 adminId);
      #endregion

      #region Custom

      #endregion

    }
    }

