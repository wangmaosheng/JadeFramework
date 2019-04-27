using JadeFramework.Core.Extensions;
using System;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 工作流实体基类
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 实例化
        /// </summary>
        public Entity()
        {
            this.CreateTime = DateTime.Now.ToTimeStamp();
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual long CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual string CreateUserId { get; set; }
    }
}
