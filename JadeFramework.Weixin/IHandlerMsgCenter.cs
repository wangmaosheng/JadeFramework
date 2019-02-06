using JadeFramework.Weixin.Models.RequestMsg;
using JadeFramework.Weixin.Models.ResponseMsg;

namespace JadeFramework.Weixin
{
    /// <summary>
    /// 消息处理接口
    /// </summary>
    public interface IHandlerMsgCenter
    {

        /// <summary>
        /// 当前消息基类（转换之后，得到请求消息的枚举类型）
        /// </summary>
        RequestRootMsg CurrentRootMsg { get; set; }

        #region 消息处理

        /// <summary>
        /// 默认处理信息（返回文本）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseRootMsg OnDefault(IRequestRootMsg request);

        /// <summary>
        /// 文本请求处理
        /// </summary>
        /// <param name="request">文本请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnTextRequest(RequestTextMsg request);

        /// <summary>
        /// 图片请求处理
        /// </summary>
        /// <param name="request">图片请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnImageRequest(RequestImageMsg request);

        /// <summary>
        /// 语音请求处理
        /// </summary>
        /// <param name="request">语音请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnVoiceRequest(RequestVoiceMsg request);

        /// <summary>
        /// 视频请求处理
        /// </summary>
        /// <param name="request">视频请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnVideoRequest(RequestVideoMsg request);

        /// <summary>
        /// 小视频请求处理
        /// </summary>
        /// <param name="request">小视频请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnShortVideoRequest(RequestShortVideoMsg request);

        /// <summary>
        /// 地理位置请求处理
        /// </summary>
        /// <param name="request">地理位置请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnLocationRequest(RequestLocationMsg request);

        /// <summary>
        /// 链接信息请求处理
        /// </summary>
        /// <param name="request">链接请求实体</param>
        /// <returns></returns>
        ResponseRootMsg OnLinkRequest(RequestLinkMsg request);


        /// <summary>
        /// 具体处理信息并指向具体返回响应用户方法
        /// </summary>
        /// <returns></returns>
        ResponseRootMsg ToHandlerMessage();

        #endregion

        #region 方法执行

        /// <summary>
        /// 执行之前操作
        /// </summary>
        /// <param name="requestRootMsg"></param>
        void OnActionExecuting(RequestRootMsg requestRootMsg);

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        string ExecuteResult();

        /// <summary>
        /// 执行之后操作
        /// </summary>
        /// <param name="requestRootMsg"></param>
        void OnActionExecuted(RequestRootMsg requestRootMsg);

        #endregion


    }
}