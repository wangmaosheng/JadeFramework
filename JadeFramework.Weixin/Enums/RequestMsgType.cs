using System.ComponentModel;

namespace JadeFramework.Weixin.Enums
{
    /// <summary>
    /// 微信响应消息类型
    /// </summary>
    public enum RequestMsgType : int
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Description("文本请求")]
        Text = 1,
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片请求")]
        Image = 2,
        /// <summary>
        /// 语音
        /// </summary>
        [Description("语音请求")]
        Voice = 3,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频请求")]
        Video = 4,
        /// <summary>
        /// 地理位置
        /// </summary>
        [Description("地理位置请求")]
        Location = 5,
        /// <summary>
        /// 链接信息
        /// </summary>
        [Description("链接信息请求")]
        Link = 6,
        /// <summary>
        /// 小视频
        /// </summary>
        [Description("小视频请求")]
        ShortVideo = 7,
        /// <summary>
        /// 事件推送类型
        /// </summary>
        [Description("事件推送类型")]
        Event = 8,
    }
}
