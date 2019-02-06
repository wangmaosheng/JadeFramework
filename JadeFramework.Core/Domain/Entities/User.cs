using System;

namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class UserIdentity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImg { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public UserSex Sex { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        ///  其他属性
        /// </summary>
        public object Other { get; set; }
    }

    /// <summary>
    /// 用户性别
    /// </summary>
    public enum UserSex
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 先生
        /// </summary>
        Male = 1,
        /// <summary>
        /// 女士
        /// </summary>
        Female = 2,
    }
}
