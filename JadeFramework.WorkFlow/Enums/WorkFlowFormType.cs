using System.ComponentModel;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程表单类型
    /// </summary>
    public enum WorkFlowFormType
    {
        /// <summary>
        /// 自定义表单
        /// </summary>
        [Description("自定义表单")]
        Custom = 0,
        /// <summary>
        /// 系统表单
        /// </summary>
        [Description("系统表单")]
        System = 1
    }
}
