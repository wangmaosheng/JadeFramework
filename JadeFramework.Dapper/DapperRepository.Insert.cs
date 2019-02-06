using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace JadeFramework.Dapper
{
    /// <summary>
    ///     Base Repository
    /// </summary>
    public partial class DapperRepository<TEntity>
        where TEntity : class
    {
        /// <inheritdoc />
        public virtual bool Insert(TEntity instance)
        {
            return Insert(instance, null);
        }

        /// <inheritdoc />
        public virtual bool Insert(TEntity instance, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetInsert(instance);
            if (SqlGenerator.IsIdentity)
            {
                var newId = Connection.Query<long>(queryResult.GetSql(), queryResult.Param, transaction).FirstOrDefault();
                return SetValue(newId, instance);
            }
            return Connection.Execute(queryResult.GetSql(), instance, transaction) > 0;
        }

        /// <inheritdoc />
        public virtual Task<bool> InsertAsync(TEntity instance)
        {
            return InsertAsync(instance, null);
        }
        /// <summary>
        /// 插入实体返回主键
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public virtual async Task<int> InsertReturnIdAsync(TEntity instance)
        {
            return await Connection.InsertAsync(instance,null);
        }

        /// <summary>
        /// 插入实体返回主键
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual async Task<int> InsertReturnIdAsync(TEntity instance, IDbTransaction transaction)
        {
            return await Connection.InsertAsync(instance, transaction);
        }

        /// <inheritdoc />
        public virtual async Task<bool> InsertAsync(TEntity instance, IDbTransaction transaction)
        {
            var queryResult = SqlGenerator.GetInsert(instance);
            if (SqlGenerator.IsIdentity)
            {
                var newId = (await Connection.QueryAsync<long>(queryResult.GetSql(), queryResult.Param, transaction)).FirstOrDefault();
                return SetValue(newId, instance);
            }
            return await Connection.ExecuteAsync(queryResult.GetSql(), instance, transaction) > 0;
        }

        private bool SetValue(long newId, TEntity instance)
        {
            var added = newId > 0;
            if (added)
            {
                var newParsedId = Convert.ChangeType(newId, SqlGenerator.IdentitySqlProperty.PropertyInfo.PropertyType);
                SqlGenerator.IdentitySqlProperty.PropertyInfo.SetValue(instance, newParsedId);
            }
            return added;
        }
    }
}