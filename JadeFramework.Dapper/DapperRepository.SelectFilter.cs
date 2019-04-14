using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JadeFramework.Dapper
{
    /// <summary>
    /// 查询仓储过滤 =>用于数据筛选
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial class DapperRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="filterSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> QueryFilter(string sql,string filterSql, object param = null)
        {
            return Connection.Query<TEntity>(sql + filterSql, param);
        }
    }
}
