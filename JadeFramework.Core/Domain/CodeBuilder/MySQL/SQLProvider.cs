namespace JadeFramework.Core.Domain.CodeBuilder.MySQL
{
    public class SQLProvider
    {
        public static string GetTableSql(string databasename)
        {
            string sql = $"SELECT TABLE_NAME,TABLE_TYPE,TABLE_COMMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{databasename}' ";
            return sql;
        }

        public static string GetTableColumnsSql(string databasename,string tablename)
        {
            string sql = $"SELECT TABLE_NAME,COLUMN_NAME,IS_NULLABLE,DATA_TYPE,COLUMN_COMMENT,COLUMN_KEY,CHARACTER_MAXIMUM_LENGTH  FROM information_schema.`COLUMNS` WHERE TABLE_SCHEMA = '{databasename}' AND TABLE_NAME = '{tablename}'";
            return sql;
        }
    }
}
