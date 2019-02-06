namespace JadeFramework.Core.Domain.CodeBuilder.MySQL
{
    /// <summary>
    /// 表列信息
    /// </summary>
    public class TableColumn
    {
        /// <summary>
        /// 表明
        /// </summary>
        public string TABLE_NAME { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string COLUMN_NAME { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>
        public string IS_NULLABLE { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string DATA_TYPE { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string COLUMN_COMMENT { get; set; }

        /// <summary>
        /// 主键/外键
        /// </summary>
        public string COLUMN_KEY { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public System.UInt64? CHARACTER_MAXIMUM_LENGTH { get; set; }
    }
}
