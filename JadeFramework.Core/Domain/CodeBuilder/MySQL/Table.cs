namespace JadeFramework.Core.Domain.CodeBuilder.MySQL
{
    /// <summary>
    /// 表
    /// </summary>
    public class Table
    {
        /// <summary>
        /// 表明
        /// </summary>
        public string TABLE_NAME { get; set; }

        /// <summary>
        /// 表类型
        /// </summary>
        public string TABLE_TYPE { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        public string TABLE_COMMENT { get; set; }
    }
}
