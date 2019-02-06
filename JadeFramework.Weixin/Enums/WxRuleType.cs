using System.ComponentModel;

namespace JadeFramework.Weixin.Enums
{
    /// <summary>
    /// 微信规则类型
    /// </summary>
    public enum WxRuleType
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,
        /// <summary>
        /// 用户关注回复
        /// </summary>
        [Description("订阅")]
        Subscribe = 1,
        /// <summary>
        /// 未匹配到回复规则
        /// </summary>
        [Description("未匹配到回复")]
        Unmatched = 2,
    }
}
