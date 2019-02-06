using System.Collections.Generic;

namespace JadeFramework.Core.Domain.Permission
{
    /// <summary>
    /// 用户权限
    /// </summary>
    public class UserPermission
    {
        /// <summary>
        /// 菜单
        /// </summary>
        public IEnumerable<Menu> Menus { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public IEnumerable<Role> Roles { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public object Others { get; set; }
    }
}
