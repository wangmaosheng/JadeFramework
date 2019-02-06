using JadeFramework.Weixin.Enums;

namespace JadeFramework.Weixin.Models.RequestMsg.Events
{
    /// <summary>
    /// 取消订阅事件消息
    /// </summary>
    public class RequestUnSubscribeEventMsg : RequestEventRootMsg
    {
        /// <summary>
        /// 取消订阅
        /// </summary>
        public override RequestEventType Event => RequestEventType.UnSubscribe;
    }
}
