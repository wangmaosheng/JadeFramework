using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class RequestImageMsg : RequestRootMsg
    {
        /// <summary>
        /// 图片类型
        /// </summary>
        public override RequestMsgType MsgType => RequestMsgType.Image;

        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
    }
}
