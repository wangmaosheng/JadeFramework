using JadeFramework.Core.Domain.Entities;
using System.Threading.Tasks;

namespace JadeFramework.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">实体表</param>
        /// <returns>返回更新后的实体</returns>
        IEntity Insert(IEntity entity);


        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        IEntity Update(IEntity entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        void Delete(IEntity entity);

        /// <summary>
        /// 提交
        /// </summary>
        int Commit();

        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

    }
}
