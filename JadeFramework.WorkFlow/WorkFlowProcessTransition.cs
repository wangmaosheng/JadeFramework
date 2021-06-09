using System;
using System.Collections.Generic;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程流转实体
    /// </summary>
    public class WorkFlowProcessTransition
    {
        /// <summary>
        /// 流程id
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// 实例id
        /// </summary>
        public Guid InstanceId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 菜单类型
        /// 操作类型
        /// </summary>
        public WorkFlowMenu MenuType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string ProcessContent { get; set; }
        /// <summary>
        /// 驳回类型
        /// </summary>
        public NodeRejectType? NodeRejectType { get; set; }
        /// <summary>
        /// 当驳回类型为<see cref="NodeRejectType.ForOneStep"/>时候的那个节点ID
        /// </summary>
        public Guid? RejectNodeId { get; set; }
        /// <summary>
        /// 流程状态改变实体
        /// </summary>
        public WorkFlowStatusChange StatusChange { get; set; }
        /// <summary>
        /// 流程委托实体
        /// </summary>
        public FlowAssign Assign { get; set; }
        /// <summary>
        /// 参数信息
        /// 用于节点获取、条件判断
        /// </summary>
        public Dictionary<string, object> OptionParams { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public object Extend { get; set; }
    }
}
