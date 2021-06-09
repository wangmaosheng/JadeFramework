namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 流程委托实体
    /// </summary>
    public class FlowAssign
    {
        /// <summary>
        /// 委托人id
        /// </summary>
        public string AssignUserId { get; set; }

        /// <summary>
        /// 委托人姓名
        /// </summary>
        public string AssignUserName { get; set; }

        /// <summary>
        /// 委托信息
        /// </summary>
        public string AssignContent { get; set; }
    }
}
