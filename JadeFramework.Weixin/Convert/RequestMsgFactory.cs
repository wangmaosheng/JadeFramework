using JadeFramework.Weixin.Enums;
using JadeFramework.Weixin.Models.RequestMsg;
using JadeFramework.Weixin.Models.RequestMsg.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Xml;

namespace JadeFramework.Weixin.Convert
{
    public static class RequestMsgFactory
    {
        /// <summary>
        /// 根据XML转换成相应的实体
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static RequestRootMsg ConvertEntity(string xml)
        {
            //将xml字符串解析成JObject对象
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeObject(doc);
            JObject jo = (JObject)JObject.Parse(json)["xml"];
            RequestRootMsg rootMsg = ParseRequestRootMsg(jo);
            switch (rootMsg.MsgType)
            {
                case RequestMsgType.Text:
                    rootMsg = rootMsg.ToTextMsg(jo);
                    break;
                case RequestMsgType.Location:
                    rootMsg = rootMsg.ToLocationMsg(jo);
                    break;
                case RequestMsgType.Image:
                    rootMsg = rootMsg.ToImageMsg(jo);
                    break;
                case RequestMsgType.Voice:
                    rootMsg = rootMsg.ToVideoMsg(jo);
                    break;
                case RequestMsgType.Video:
                    rootMsg = rootMsg.ToVideoMsg(jo);
                    break;
                case RequestMsgType.Link:
                    rootMsg = rootMsg.ToLinkMsg(jo);
                    break;
                case RequestMsgType.ShortVideo:
                    rootMsg = rootMsg.ToShortVideoMsg(jo);
                    break;
                case RequestMsgType.Event:
                    {
                        RequestEventType eventType = GetRequestEventType(jo);
                        switch (eventType)
                        {
                            case RequestEventType.Subscribe:
                                rootMsg = rootMsg.ToSubscribeEventMsg(jo);
                                break;
                            case RequestEventType.UnSubscribe:
                                rootMsg = rootMsg.ToUnSubscribeEventMsg(jo);
                                break;
                            default:
                                throw new ArgumentNullException("消息/事件类型未匹配到！");
                        }
                    }
                    break;
                default:
                    throw new ArgumentNullException("消息/事件类型未匹配到！");
            }

            return rootMsg;
        }
        #region 消息处理
        /// <summary>
        /// 将xml节点CDATA转换成json之后的键名
        /// </summary>
        private const string CDATA_KEY = "#cdata-section";

        /// <summary>
        /// 根据JObject得到请求消息基类基本信息
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestRootMsg ParseRequestRootMsg(JObject jObject)
        {
            RequestRootMsg rootMsg = new RequestRootMsg
            {
                ToUserName = (string)jObject["ToUserName"][CDATA_KEY],
                FromUserName = (string)jObject["FromUserName"][CDATA_KEY],
                CreateTime = (long)jObject["CreateTime"]
            };
            string msgType = (string)jObject["MsgType"][CDATA_KEY];
            rootMsg.MsgType = (RequestMsgType)Enum.Parse(typeof(RequestMsgType), msgType, true);
            return rootMsg;
        }
        private static Logger nlog = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 获取事件类型
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestEventType GetRequestEventType(JObject jObject)
        {
            string eventstr = (string)jObject["Event"][CDATA_KEY];
            nlog.Info(eventstr);
            RequestEventType eventType = (RequestEventType)Enum.Parse(typeof(RequestEventType), eventstr, true);
            nlog.Info(eventType.ToString());
            return eventType;
        }

        /// <summary>
        /// JObject转换成文本信息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestTextMsg ToTextMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestTextMsg textMsg = new RequestTextMsg
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                Content = (string)jObject["Content"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return textMsg;
        }

        /// <summary>
        /// 转换成图片信息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestImageMsg ToImageMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestImageMsg imageMsg = new RequestImageMsg()
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                PicUrl = (string)jObject["PicUrl"][CDATA_KEY],
                MediaId = (string)jObject["MediaId"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return imageMsg;
        }

        /// <summary>
        /// 转换成语音消息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestVoiceMsg ToVoiceMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestVoiceMsg voiceMsg = new RequestVoiceMsg()
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                MediaId = (string)jObject["MediaId"][CDATA_KEY],
                Format = (string)jObject["Format"][CDATA_KEY],
                Recognition = (string)jObject["Recognition"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return voiceMsg;
        }

        /// <summary>
        /// 转换成视频消息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestVideoMsg ToVideoMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestVideoMsg videoMsg = new RequestVideoMsg()
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                MediaId = (string)jObject["MediaId"][CDATA_KEY],
                ThumbMediaId = (string)jObject["ThumbMediaId"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return videoMsg;
        }

        /// <summary>
        /// 转换成小视频信息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestShortVideoMsg ToShortVideoMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestShortVideoMsg shortVideoMsg = new RequestShortVideoMsg()
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                MediaId = (string)jObject["MediaId"][CDATA_KEY],
                ThumbMediaId = (string)jObject["ThumbMediaId"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return shortVideoMsg;
        }

        /// <summary>
        /// 转换成地理位置信息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestLocationMsg ToLocationMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestLocationMsg locationMsg = new RequestLocationMsg()
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                Location_X = (double)jObject["Location_X"],
                Location_Y = (double)jObject["Location_Y"],
                Scale = (int)jObject["Scale"],
                Label = (string)jObject["Label"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return locationMsg;
        }

        /// <summary>
        /// 转换成链接信息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestLinkMsg ToLinkMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestLinkMsg linkMsg = new RequestLinkMsg()
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName,
                Title = (string)jObject["Title"][CDATA_KEY],
                Description = (string)jObject["Description"][CDATA_KEY],
                Url = (string)jObject["Url"][CDATA_KEY],
                MsgId = (long)jObject["MsgId"]
            };
            return linkMsg;
        }

        /// <summary>
        /// 转成订阅消息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestSubscribeEventMsg ToSubscribeEventMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestSubscribeEventMsg subscribeEventMsg = new RequestSubscribeEventMsg
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName
            };
            return subscribeEventMsg;
        }
        /// <summary>
        /// 转成取消订阅信息
        /// </summary>
        /// <param name="rootMsg"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static RequestUnSubscribeEventMsg ToUnSubscribeEventMsg(this RequestRootMsg rootMsg, JObject jObject)
        {
            RequestUnSubscribeEventMsg unSubscribeEventMsg = new RequestUnSubscribeEventMsg
            {
                CreateTime = rootMsg.CreateTime,
                FromUserName = rootMsg.FromUserName,
                ToUserName = rootMsg.ToUserName
            };
            return unSubscribeEventMsg;
        }
        #endregion
    }
}
