using System;

namespace JadeFramework.Core.Attributes
{
    /// <summary>
    /// 枚举描述特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        /// 枚举注释
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 构造器传入枚举描述注释
        /// </summary>
        /// <param name="description">枚举描述注释</param>
        public EnumDescriptionAttribute(string description)
        {
            this.Description = description;
        }
    }
}
