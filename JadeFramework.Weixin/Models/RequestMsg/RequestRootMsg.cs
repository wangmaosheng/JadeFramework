using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg
{
    /// <summary>
    /// 微信端响应信息基类接口
    /// （转换）
    /// </summary>
    public interface IRequestRootMsg
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 时间戳（整型）
        /// </summary>
        long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        RequestMsgType MsgType { get; set; }

        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        long MsgId { get; set; }
    }

    /// <summary>
    /// 微信端响应信息基类
    /// </summary>
    public class RequestRootMsg: IRequestRootMsg
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 时间戳（整型）
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public virtual RequestMsgType MsgType { get; set; }

        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
    }
}
