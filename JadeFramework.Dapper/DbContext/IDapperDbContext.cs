using System;
using System.Data;

namespace JadeFramework.Dapper.DbContext
{
    /// <summary>
    ///     Class is helper for use and close IDbConnection
    /// </summary>
    public interface IDapperDbContext : IDisposable
    {
        /// <summary>
        ///     Get opened DB Connection
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        ///     Open DB connection
        /// </summary>
        void OpenConnection();

        /// <summary>
        ///     Open DB connection and Begin transaction
        /// </summary>
        IDbTransaction BeginTransaction();
    }
}