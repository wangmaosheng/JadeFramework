namespace JadeFramework.Core
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual byte IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual long CreateTime { get; set; }
    }
}
