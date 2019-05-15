using System;
using System.Collections.Generic;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程进程实体
    /// </summary>
    public class WorkFlowProcess
    {
        /// <summary>
        /// 流程id
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }
        /// <summary>
        /// 实例id
        /// </summary>
        public Guid InstanceId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 可操作按钮集合
        /// <see cref="WorkFlowMenu"/>集合
        /// </summary>
        public List<int> Menus { get; set; }
        /// <summary>
        /// 表单id
        /// </summary>
        public Guid FormId { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        public WorkFlowFormType FormType { get; set; }
        /// <summary>
        /// 表单内容
        /// </summary>
        public string FormContent { get; set; }
        /// <summary>
        /// 表单数据
        /// </summary>
        public string FormData { get; set; }
        /// <summary>
        /// 表单地址
        /// </summary>
        public string FormUrl { get; set; }

        /// <summary>
        /// 执行过的任务节点
        /// </summary>
        public List<FlowNode> ExecutedNode { get; set; }
    }
}
