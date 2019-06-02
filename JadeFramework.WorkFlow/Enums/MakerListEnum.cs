using System.Collections.Generic;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 审核人类型
    /// </summary>
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
        Roles,
        /// <summary>
        /// 通过SQL获取
        /// </summary>
        SQL
    }
    /// <summary>
    /// 审核人实体
    /// </summary>
    public class MakerListModel
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public List<long> UserIds { get; set; }

        /// <summary>
        /// 人员类型
        /// </summary>
        public MakerListEnum MakerType { get; set; }
    }
}
