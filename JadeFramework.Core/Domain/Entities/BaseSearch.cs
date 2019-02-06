namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// 搜索基类
    /// </summary>
    public class BaseSearch
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 显示状态
        /// </summary>
        public int IsDel { get; set; }

        /// <summary>
        /// OffSet
        /// </summary>
        /// <returns></returns>
        public virtual int OffSet()
        {
            return this.PageSize * (this.PageIndex - 1);
        }
    }
}
