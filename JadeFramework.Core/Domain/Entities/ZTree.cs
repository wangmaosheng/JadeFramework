namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// ztree树 数据结构
    /// </summary>
    public class ZTree
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public object pId { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        public bool open { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool @checked {get;set;}
    }
}
