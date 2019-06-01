using System.Collections.Generic;

namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// 分页实体
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    public class Page<TEntity> where TEntity : class
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public Page()
        {
            this.Items = new List<TEntity>();
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 查询集合总个数
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// 每页项数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 查询集合
        /// </summary>
        public IEnumerable<TEntity> Items { get; set; }

    }
}
