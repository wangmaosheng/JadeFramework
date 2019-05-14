using System;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程状态修改实体
    /// </summary>
    public class WorkFlowStatusChange
    {
        /// <summary>
        /// 主键名称
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// 主键值
        /// </summary>
        public string KeyValue { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public WorkFlowStatus Status { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 流程操作时间
        /// </summary>
        public long FlowTime { get; set; }

        /// <summary>
        /// CAP订阅名称
        /// </summary>
        public string TargetName { get; set; }
    }
}
