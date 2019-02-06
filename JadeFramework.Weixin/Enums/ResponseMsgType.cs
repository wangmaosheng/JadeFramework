using System.ComponentModel;

namespace JadeFramework.Weixin.Enums
{
    /// <summary>
    /// 回复消息类型
    /// </summary>
    public enum ResponseMsgType : int
    {
        /// <summary>
        /// 文本回复
        /// </summary>
        [Description("文本回复")]
        Text = 1,
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片回复")]
        Image = 2,
        /// <summary>
        /// 语音
        /// </summary>
        [Description("语音回复")]
        Voice = 3,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频回复")]
        Video = 4,
        /// <summary>
        /// 音乐
        /// </summary>
        [Description("音乐回复")]
        Music = 5,
        /// <summary>
        /// 图文
        /// </summary>
        [Description("图文回复")]
        News = 6,
        /// <summary>
        /// 转发客服
        /// </summary>
        [Description("转发客服")]
        Transfer_Customer_Service = 7
    }
}
