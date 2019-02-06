using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class RequestVoiceMsg : RequestRootMsg
    {
        /// <summary>
        /// 语音
        /// </summary>
        public override RequestMsgType MsgType => RequestMsgType.Voice;

        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 语音识别结果，UTF8编码
        /// </summary>
        public string Recognition { get; set; }
    }
}
