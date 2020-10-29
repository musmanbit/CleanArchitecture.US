
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.US.Application.Interface
{
    public interface IBaseApplication<T>
    {
        /// <summary>
        /// Get Details by entity Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<T> GetById(Int32 entityId);
        /// <summary>
        /// Delete by entity Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<T> Save(T entity, bool createTransaction);
    }
}
