using JadeFramework.Weixin.Convert;
using JadeFramework.Weixin.Enums;
using JadeFramework.Weixin.Models;
using JadeFramework.Weixin.Models.RequestMsg;
using JadeFramework.Weixin.Models.RequestMsg.Events;
using JadeFramework.Weixin.Models.ResponseMsg;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JadeFramework.Weixin
{
    /// <summary>
    /// 微信接口接入
    /// </summary>
    public abstract class WxApiController : Controller
    {


        #region GET/POST


        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="authSignature"></param>
        /// <returns></returns>
        [ActionName("Index")]
        [HttpPost]
        public abstract IActionResult Post([FromBody]AuthSignature authSignature);

        #endregion

        /// <summary>
        /// 当前消息基类（转换之后，得到请求消息的枚举类型）
        /// </summary>
        protected RequestRootMsg CurrentRootMsg { get; set; }

        /// <summary>
        /// 签名认证实体信息
        /// </summary>
        protected AuthSignature AuthSignature { get; set; }

        protected void ConvertEntity(string xml)
        {
            CurrentRootMsg = RequestMsgFactory.ConvertEntity(xml);
        }


        #region 消息处理

        /// <summary>
        /// 默认处理信息（返回文本）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnDefault(IRequestRootMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 文本请求处理
        /// </summary>
        /// <param name="request">文本请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnTextRequest(RequestTextMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 图片请求处理
        /// </summary>
        /// <param name="request">图片请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnImageRequest(RequestImageMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 语音请求处理
        /// </summary>
        /// <param name="request">语音请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnVoiceRequest(RequestVoiceMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 视频请求处理
        /// </summary>
        /// <param name="request">视频请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnVideoRequest(RequestVideoMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 小视频请求处理
        /// </summary>
        /// <param name="request">小视频请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnShortVideoRequest(RequestShortVideoMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 地理位置请求处理
        /// </summary>
        /// <param name="request">地理位置请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnLocationRequest(RequestLocationMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 链接信息请求处理
        /// </summary>
        /// <param name="request">链接请求实体</param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnLinkRequest(RequestLinkMsg request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnEvent_SubscribeRequest(RequestSubscribeEventMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual ResponseRootMsg OnEvent_UnSubscribeRequest(RequestUnSubscribeEventMsg request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 具体处理信息并指向具体返回响应用户方法
        /// </summary>
        /// <returns></returns>
        protected virtual ResponseRootMsg ToHandlerMessage()
        {
            ResponseRootMsg response = null;
            switch (CurrentRootMsg.MsgType)
            {
                case RequestMsgType.Text:
                    response = OnTextRequest(CurrentRootMsg as RequestTextMsg);
                    break;
                case RequestMsgType.Location:
                    response = OnLocationRequest(CurrentRootMsg as RequestLocationMsg);
                    break;
                case RequestMsgType.Image:
                    response = OnImageRequest(CurrentRootMsg as RequestImageMsg);
                    break;
                case RequestMsgType.Voice:
                    response = OnVoiceRequest(CurrentRootMsg as RequestVoiceMsg);
                    break;
                case RequestMsgType.Video:
                    response = OnVideoRequest(CurrentRootMsg as RequestVideoMsg);
                    break;
                case RequestMsgType.Link:
                    response = OnLinkRequest(CurrentRootMsg as RequestLinkMsg);
                    break;
                case RequestMsgType.ShortVideo:
                    response = OnShortVideoRequest(CurrentRootMsg as RequestShortVideoMsg);
                    break;
                case RequestMsgType.Event:
                    {
                        RequestEventRootMsg eventRootMsg = CurrentRootMsg as RequestEventRootMsg;
                        switch (eventRootMsg.Event)
                        {
                            case RequestEventType.Subscribe:
                                response = OnEvent_SubscribeRequest(eventRootMsg as RequestSubscribeEventMsg);
                                break;
                            case RequestEventType.UnSubscribe:
                                response = OnEvent_UnSubscribeRequest(eventRootMsg as RequestUnSubscribeEventMsg);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            return response;
        }

        #endregion


        #region 方法执行

        /// <summary>
        /// 执行之前操作
        /// </summary>
        /// <param name="requestRootMsg"></param>
        protected virtual void OnActionExecuting(RequestRootMsg requestRootMsg)
        {

        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        protected string ExecuteResult()
        {
            //1、执行之前操作
            OnActionExecuting(CurrentRootMsg);
            //2、开始执行
            ResponseRootMsg response = ToHandlerMessage();
            string xml = response.ToXml();
            //3、执行之后操作
            OnActionExecuted(CurrentRootMsg);
            return xml;
        }


        /// <summary>
        /// 执行之后操作
        /// </summary>
        /// <param name="requestRootMsg"></param>
        protected virtual void OnActionExecuted(RequestRootMsg requestRootMsg)
        {

        }

        #endregion
    }
}
