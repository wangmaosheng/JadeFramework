using System.Collections.Generic;

namespace JadeFramework.WorkFlow
{
    public enum MakerListEnum
    {
        /// <summary>
        /// 未找到任何类型
        /// </summary>
        None,
        /// <summary>
        /// 所有人
        /// </summary>
        AllUser,
        /// <summary>
        /// 指定某些人
        /// </summary>
        Users,
        /// <summary>
        /// 指定某些角色
        /// </summary>
        Roles
    }
    public class MakerListModel
    {
        public List<long> UserIds { get; set; }
        public MakerListEnum MakerType { get; set; }
    }
}
