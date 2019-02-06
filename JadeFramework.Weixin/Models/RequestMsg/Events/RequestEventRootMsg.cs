using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg.Events
{
    /// <summary>
    /// 事件请求基类
    /// </summary>
    public abstract class RequestEventRootMsg : RequestRootMsg
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public virtual RequestEventType Event { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public override RequestMsgType MsgType => RequestMsgType.Event;

    }
}
