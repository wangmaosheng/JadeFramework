using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg.Events
{
    /// <summary>
    /// 订阅事件消息
    /// </summary>
    public class RequestSubscribeEventMsg: RequestEventRootMsg
    {
        /// <summary>
        /// 订阅事件
        /// </summary>
        public override RequestEventType Event => RequestEventType.Subscribe;
    }
}
