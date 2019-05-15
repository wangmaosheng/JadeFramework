using System.ComponentModel;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程按钮
    /// </summary>
    public enum WorkFlowMenu
    {
        /// <summary>
        /// 返回
        /// </summary>
        [Description("返回")]
        Return = -1,
        /// <summary>
        /// 保存
        /// </summary>
        [Description("保存")]
        Save = 0,
        /// <summary>
        /// 提交
        /// </summary>
        [Description("提交")]
        Submit = 1,
        /// <summary>
        /// 再次提交
        /// </summary>
        [Description("再次提交")]
        ReSubmit = 101,
        /// <summary>
        /// 同意
        /// </summary>
        [Description("同意")]
        Agree = 2,
        /// <summary>
        /// 不同意
        /// </summary>
        [Description("不同意")]
        Deprecate = 3,
        /// <summary>
        /// 弃权
        /// </summary>
        [Description("弃权")]
        Cancel = 4,
        /// <summary>
        /// 直送
        /// </summary>
        [Description("直送")]
        Throgh = 5,
        /// <summary>
        /// 委托
        /// </summary>
        [Description("委托")]
        Assign = 6,
        /// <summary>
        /// 退回
        /// </summary>
        [Description("退回")]
        Back = 7,
        /// <summary>
        /// 终止
        /// </summary>
        [Description("终止")]
        Stop = 8,
        /// <summary>
        /// 已阅
        /// </summary>
        [Description("已阅")]
        View = 9,
        /// <summary>
        /// 流程图
        /// </summary>
        [Description("流程图")]
        FlowImage = 10,
        /// <summary>
        /// 审批意见
        /// </summary>
        [Description("审批意见")]
        Approval = 11,
        /// <summary>
        /// 抄送
        /// </summary>
        [Description("抄送")]
        CC = 12,
        /// <summary>
        /// 挂起
        /// </summary>
        [Description("挂起")]
        Suspend = 13,
        /// <summary>
        /// 回复
        /// </summary>
        [Description("回复")]
        Resume = 14,
    }
}
