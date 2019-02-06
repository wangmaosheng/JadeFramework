using JadeFramework.Core.Domain.Permission;
using System.Threading.Tasks;

namespace JadeFramework.Core.Domain.Container
{
    /// <summary>
    /// permission storage
    /// </summary>
    public interface IPermissionStorageContainer : IStorageContainer
    {
        ///// <summary>
        ///// 获取用户权限
        ///// </summary>
        ///// <returns></returns>
        //UserPermission GetPermission();

        /// <summary>
        /// 异步获取用户权限
        /// </summary>
        /// <returns></returns>
        Task<UserPermission> GetPermissionAsync();

        /// <summary>
        /// 异步初始化权限
        /// </summary>
        /// <returns></returns>
        Task InitAsync();
    }
}
