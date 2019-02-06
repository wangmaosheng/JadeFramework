using Newtonsoft.Json;
using System.ComponentModel;

namespace JadeFramework.Weixin.Enums
{
    /// <summary>
    /// 微信菜单类型
    /// </summary>
    public enum WxMenuType
    {
        [Description("View")]
        [JsonProperty("view")]
        View,
        [Description("Click")]
        [JsonProperty("click")]
        Click,
        [Description("MiniProgram")]
        [JsonProperty("miniprogram")]
        MiniProgram
    }
}
