namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 定制流程获取工作流进程DTO
    /// </summary>
    public class SystemFlowDto
    {
        /// <summary>
        /// 表单ID
        /// </summary>
        public string PageId { get; set; }
        /// <summary>
        /// 表单地址
        /// </summary>
        public string FormUrl { get; set; }
        /// <summary>
        /// 当前用户ID
        /// </summary>
        public string UserId { get; set; }
    }
}
