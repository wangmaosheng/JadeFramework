using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class RequestVideoMsg : RequestRootMsg
    {
        /// <summary>
        /// 视频
        /// </summary>
        public override RequestMsgType MsgType => RequestMsgType.Video;

        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
}
