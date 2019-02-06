using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程节点
    /// </summary>
    public class FlowNode
    {
        public const string START = "start round mix";  //开始
        public const string END = "end round";          //结束
        public const string NODE = "node";              //自动节点 =>条件判断 SQL、结果值判断，
        public const string Task = "task";              //任务节点
        public const string FORK = "fork";              //分流 =>代表一个任务可以走多个分支
        public const string JOIN = "join";              //合流 =>代表合并多个分支得出最终的结果
        public const string Chat = "chat";              //会签 串行/并行两种方式

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("setInfo")]
        public FlowNodeSetInfo SetInfo { get; set; }

        /// <summary>
        /// 获取节点枚举类型
        /// </summary>
        /// <returns></returns>
        public WorkFlowInstanceNodeType NodeType()
        {
            switch (this.Type)
            {
                case FlowNode.START:
                    return WorkFlowInstanceNodeType.BeginRound;
                case FlowNode.END:
                    return WorkFlowInstanceNodeType.EndRound;
                case FlowNode.Task:
                    return WorkFlowInstanceNodeType.Normal;
                case FlowNode.FORK:
                    return WorkFlowInstanceNodeType.ForkNode;
                case FlowNode.JOIN:
                    return WorkFlowInstanceNodeType.JoinNode;
                case FlowNode.Chat:
                    return WorkFlowInstanceNodeType.ChatNode;
                case FlowNode.NODE:
                    return WorkFlowInstanceNodeType.ConditionNode;
                default:
                    return WorkFlowInstanceNodeType.NotRun;
            }
        }
    }
    public static class FlowNodeExtension
    {
        /// <summary>
        /// 判断节点是否结束
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public static int ToIsFinish(this WorkFlowInstanceNodeType nodeType)
        {
            return nodeType == WorkFlowInstanceNodeType.EndRound 
                ? (int)WorkFlowInstanceStatus.IsFinish 
                : (int)WorkFlowInstanceStatus.Running;
        }

    }

    /// <summary>
    /// 节点信息
    /// </summary>
    public class FlowNodeSetInfo
    {
        /// <summary>
        /// 节点执行人
        /// </summary>
        [JsonProperty("Nodedesignatedata")]
        public Nodedesignatedata Nodedesignatedata { get; set; }

        public const string SPECIAL_USER = "SPECIAL_USER";  //指定用户
        public const string ALL_USER = "ALL_USER";  //所有用户
        public const string SPECIAL_ROLE = "SPECIAL_ROLE";
        /// <summary>
        /// 节点执行权限类型 SPECIAL_USER ALL_USER SPECIAL_ROLE
        /// </summary>
        public string NodeDesignate { get; set; }

        /// <summary>
        ///  是否是会签
        /// </summary>
        public bool IsChat { get; set; } = false;
        /// <summary>
        /// 会签数据
        /// </summary>
        public ChatData ChatData { get; set; }
    }

    /// <summary>
    /// 节点执行人
    /// </summary>
    public class Nodedesignatedata
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        [JsonProperty("users")]
        public string[] Users { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        [JsonProperty("orgs")]
        public string[] Orgs { get; set; }
    }

    /// <summary>
    /// 驳回节点0"前一步"1"第一步"2"某一步" 3"不处理"
    /// </summary>
    public enum NodeRejectType
    {
        /// <summary>
        /// 前一步
        /// </summary>
        [Description("前一步")]
        PreviousStep = 0,
        /// <summary>
        /// 第一步
        /// </summary>
        [Description("第一步")]
        FirstStep = 1,
        /// <summary>
        /// 某一步
        /// </summary>
        [Description("某一步")]
        ForOneStep = 2,
        /// <summary>
        /// 不处理
        /// </summary>
        [Description("不处理")]
        UnHandled = 3
    }
}
