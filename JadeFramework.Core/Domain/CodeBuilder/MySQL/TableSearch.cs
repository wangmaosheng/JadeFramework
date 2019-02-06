namespace JadeFramework.Core.Domain.CodeBuilder.MySQL
{
    public class TableSearch
    {
        /// <summary>
        /// databse
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// datasource
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// userid
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 生成类型
        /// </summary>
        public byte Type { get; set; }
    }
}
