using System;
using System.Collections.Generic;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// workflow context model
    /// </summary>
    public class WorkFlow
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        public Guid FlowId { get; set; }

        /// <summary>
        /// 流程实例ID
        /// </summary>
        public Guid InstanceId { get; set; }

        /// <summary>
        /// 开始节点ID
        /// </summary>
        public Guid StartNodeId { get; set; }

        /// <summary>
        /// 上一个节点ID
        /// </summary>
        public Guid PreviousId { get; set; }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        public Guid ActivityNodeId { get; set; }

        /// <summary>
        /// 当前节点类型
        /// </summary>
        public WorkFlowInstanceNodeType ActivityNodeType { get; set; }

        /// <summary>
        /// 当前节点
        /// </summary>
        public FlowNode ActivityNode { get { return Nodes[ActivityNodeId]; } }

        /// <summary>
        /// 下个节点ID
        /// </summary>
        public Guid NextNodeId { get; set; }

        /// <summary>
        /// 下个节点类型
        /// </summary>
        public WorkFlowInstanceNodeType NextNodeType { get; set; }

        /// <summary>
        /// 下一个节点对象
        /// </summary>
        public FlowNode NextNode { get { return NextNodeId != default(Guid) ? Nodes[NextNodeId] : null; }}

        /// <summary>
        /// 全部节点
        /// </summary>
        public Dictionary<Guid, FlowNode> Nodes { get; set; }

        /// <summary>
        /// 连线集合
        /// </summary>
        public Dictionary<Guid, List<FlowLine>> Lines { get; set; }

        /// <summary>
        /// 流程图JSON
        /// </summary>
        public string FlowJSON { get; set; }
    }
}
