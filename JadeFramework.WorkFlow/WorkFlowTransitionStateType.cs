namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程流转状态
    /// </summary>
    public enum WorkFlowTransitionStateType
    {
        /// <summary>
        /// 正常通过
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 节点拒绝
        /// </summary>
        Reject = 1
    }
}
