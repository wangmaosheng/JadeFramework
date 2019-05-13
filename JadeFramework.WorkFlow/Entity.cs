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

    /// <summary>
    /// 第三方流程接入继承的实体
    /// </summary>
    public abstract class OtherEntity
    {
        /// <summary>
        /// 构造器
        /// 初始FlowStatus值为:<see cref="WorkFlowStatus.UnSubmit"/>
        /// </summary>
        public OtherEntity()
        {
            this.FlowStatus = (int)WorkFlowStatus.UnSubmit;
        }

        /// <summary>
        /// 流程状态
        /// </summary>
        public virtual int FlowStatus { get; set; }
        /// <summary>
        /// 流程操作时间戳
        /// </summary>
        public virtual long FlowTime { get; set; }
    }
}
