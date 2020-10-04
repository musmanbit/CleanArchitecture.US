using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;



namespace CleanArchitecture.US.Infrastructure.Interface
{
    public interface IBaseInfrastructure<T>
    {

        Task<T> GetById(Int32 entityId);
        Task<bool> Delete(T entity);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<int> Update(IList<T> entities);     
        Task<IList<T>> GetAll();
        /*  /// <summary>
          /// 
          /// </summary>
          /// <param name="reader"></param>
          /// <param name="rows"></param>
          /// <param name="start"></param>
          /// <param name="pageLength"></param>
          /// <returns></returns>
          Task<IList<T>> Fill(IDataReader reader, IList<T> rows, int start, int pageLength);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entityId"></param>
          /// <returns></returns>
          Task<T> GetById(Int32 entityId);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entity"></param>
          /// <returns></returns>
          Task<bool> Delete(T entity);


          Task<bool> Delete(T entity, SqlConnection connection);

          /// <summary>
          /// 
          /// </summary>
          /// <returns></returns>
          Task<IList<T>> GetAllActive();

          /// <summary>
          /// 
          /// </summary>
          /// <returns></returns>
          Task<IList<T>> GetAll();

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entity"></param>
          /// <returns></returns>
          Task<bool> Insert(T entity);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entity"></param>
          /// <param name="sqlConnection"></param>
          /// <returns></returns>
          Task<bool> Insert(T entity, SqlConnection sqlConnection);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entity"></param>
          /// <returns></returns>
          Task<bool> Update(T entity);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entity"></param>
          /// <param name="sqlConnection"></param>
          /// <returns></returns>
          Task<bool> Update(T entity, SqlConnection sqlConnection);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="entities"></param>
          /// <returns></returns>
          Task<int> Update(IList<T> entities);
          */

    }
}
