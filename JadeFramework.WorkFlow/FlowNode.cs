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
        /// <summary>
        /// 开始
        /// </summary>
        public const string START = "start round mix";
        /// <summary>
        /// 结束
        /// </summary>
        public const string END = "end round";
        /// <summary>
        /// 自动节点 =>条件判断 SQL、结果值判断
        /// </summary>
        public const string NODE = "node";
        /// <summary>
        /// 任务节点
        /// </summary>
        public const string Task = "task";
        /// <summary>
        /// 分流 =>代表一个任务可以走多个分支
        /// </summary>
        public const string FORK = "fork";
        /// <summary>
        /// 合流 =>代表合并多个分支得出最终的结果
        /// </summary>
        public const string JOIN = "join";
        /// <summary>
        /// 会签 串行/并行两种方式
        /// </summary>
        public const string Chat = "chat";

        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 节点信息
        /// </summary>
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

        /// <summary>
        /// 指定用户
        /// </summary>
        public const string SPECIAL_USER = "SPECIAL_USER";
        /// <summary>
        /// 所有用户
        /// </summary>
        public const string ALL_USER = "ALL_USER";
        /// <summary>
        /// 制定角色
        /// </summary>
        public const string SPECIAL_ROLE = "SPECIAL_ROLE";

        /// <summary>
        /// SQL自动获取
        /// </summary>
        public const string SQL = "SQL";

        /// <summary>
        /// 节点执行权限类型 SPECIAL_USER ALL_USER SPECIAL_ROLE SQL
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

        /// <summary>
        /// sql
        /// </summary>
        [JsonProperty("sql")]
        public string SQL { get; set; }
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
