namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// 路由基本实体
    /// </summary>
    public class RouteName
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Areas { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string Action { get; set; }

        ///// <summary>
        ///// 是否是编辑页面
        ///// </summary>
        //public bool IsShow { get; set; }
    }
}
