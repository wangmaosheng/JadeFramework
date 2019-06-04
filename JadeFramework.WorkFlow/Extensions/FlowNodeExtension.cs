namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程节点扩展
    /// </summary>
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
                ? (int)WorkFlowInstanceStatus.Finish
                : (int)WorkFlowInstanceStatus.Running;
        }

    }
}
