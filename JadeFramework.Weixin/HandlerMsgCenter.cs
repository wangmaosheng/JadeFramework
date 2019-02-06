using JadeFramework.Weixin.Convert;
using JadeFramework.Weixin.Enums;
using JadeFramework.Weixin.Extensions;
using JadeFramework.Weixin.Models;
using JadeFramework.Weixin.Models.RequestMsg;
using JadeFramework.Weixin.Models.ResponseMsg;
using System;

namespace JadeFramework.Weixin
{
    /// <summary>
    /// 消息处理中心抽象类
    /// </summary>
    public abstract class HandlerMsgCenter: IHandlerMsgCenter
    {
        /// <summary>
        /// 当前消息基类（转换之后，得到请求消息的枚举类型）
        /// </summary>
        public RequestRootMsg CurrentRootMsg { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="xml">微信端传入的XML字符串</param>
        /// <param name="authSignature">签名认证实体信息</param>
        public HandlerMsgCenter(string xml, AuthSignature authSignature)
        {
            //转换成实体类型
            CurrentRootMsg = RequestMsgFactory.ConvertEntity(xml);
        }


        #region 消息处理

        /// <summary>
        /// 默认处理信息（返回文本）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnDefault(IRequestRootMsg request)
        {
            ResponseTextMsg responseText = new ResponseTextMsg()
            {
                Content = "默认回复" + DateTime.Now,
                CreateTime = DateTime.Now.ToTimeStamp(),
                FromUserName = request.ToUserName,
                ToUserName = request.FromUserName
            };
            return responseText;
        }

        /// <summary>
        /// 文本请求处理
        /// </summary>
        /// <param name="request">文本请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnTextRequest(RequestTextMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 图片请求处理
        /// </summary>
        /// <param name="request">图片请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnImageRequest(RequestImageMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 语音请求处理
        /// </summary>
        /// <param name="request">语音请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnVoiceRequest(RequestVoiceMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 视频请求处理
        /// </summary>
        /// <param name="request">视频请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnVideoRequest(RequestVideoMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 小视频请求处理
        /// </summary>
        /// <param name="request">小视频请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnShortVideoRequest(RequestShortVideoMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 地理位置请求处理
        /// </summary>
        /// <param name="request">地理位置请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnLocationRequest(RequestLocationMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 链接信息请求处理
        /// </summary>
        /// <param name="request">链接请求实体</param>
        /// <returns></returns>
        public virtual ResponseRootMsg OnLinkRequest(RequestLinkMsg request)
        {
            return OnDefault(request);
        }

        /// <summary>
        /// 具体处理信息并指向具体返回响应用户方法
        /// </summary>
        /// <returns></returns>
        public virtual ResponseRootMsg ToHandlerMessage()
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
        public virtual void OnActionExecuting(RequestRootMsg requestRootMsg)
        {

        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public string ExecuteResult()
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
        public virtual void OnActionExecuted(RequestRootMsg requestRootMsg)
        {

        }

        #endregion

    }
}
