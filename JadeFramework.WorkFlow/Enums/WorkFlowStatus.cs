using System.ComponentModel;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程状态,用户操作
    /// </summary>
    public enum WorkFlowStatus : int
    {
        /// <summary>
        /// 未提交
        /// </summary>
        [Description("未提交")]
        UnSubmit = -1,
        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        Running = 0,
        /// <summary>
        /// 已结束 => 通过
        /// </summary>
        [Description("已结束")]
        IsFinish = 1,
        /// <summary>
        /// 不同意
        /// </summary>
        [Description("不同意")]
        Deprecate = 2,
        /// <summary>
        /// 流程被退回
        /// </summary>
        [Description("已退回")]
        Back = 3,
        /// <summary>
        /// 终止，流程被暂停,流程意外报错终止
        /// </summary>
        [Description("终止")]
        Stop = 4,
        /// <summary>
        /// 撤回
        /// </summary>
        [Description("撤回")]
        Withdraw = 5
    }
    /// <summary>
    /// 工作流实例运行状态
    /// </summary>
    public enum WorkFlowInstanceStatus : int
    {
        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        Running = 0,
        /// <summary>
        /// 已结束,流程实例已结束
        /// </summary>
        [Description("已结束")]
        Finish = 1
    }

    /// <summary>
    /// 工作流实例节点类型
    /// </summary>
    public enum WorkFlowInstanceNodeType : int
    {
        /// <summary>
        /// 无法运行
        /// </summary>
        [Description("无法运行")]
        NotRun = -1,
        /// <summary>
        /// 分流开始
        /// </summary>
        [Description("分流")]
        ForkNode = 0,
        /// <summary>
        /// 合流分流会和
        /// </summary>
        [Description("合流")]
        JoinNode = 1,
        /// <summary>
        /// 正常节点
        /// </summary>
        [Description("正常节点")]
        Normal = 2,
        /// <summary>
        /// 开始节点
        /// </summary>
        [Description("开始节点")]
        BeginRound = 3,
        /// <summary>
        /// 结束节点
        /// </summary>
        [Description("结束节点")]
        EndRound = 4,
        /// <summary>
        /// 会签节点
        /// </summary>
        [Description("会签")]
        ChatNode = 5,
        /// <summary>
        /// 条件节点
        /// </summary>
        [Description("条件节点")]
        ConditionNode = 6,
        /// <summary>
        /// 通知节点
        /// </summary>
        [Description("通知节点")]
        ViewNode = 7,
    }
}
