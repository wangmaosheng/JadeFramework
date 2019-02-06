using JadeFramework.Weixin.Enums;
using System.Xml;

namespace JadeFramework.Weixin.Models.ResponseMsg
{
    /// <summary>
    /// 响应语音信息
    /// </summary>
    public class ResponseVoiceMsg : ResponseRootMsg
    {
        /// <summary>
        /// 语音
        /// </summary>
        public override ResponseMsgType MsgType => ResponseMsgType.Voice;

        /// <summary>
        /// 通过素材管理中的接口上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 返回XML格式的响应消息
        /// </summary>
        /// <returns>返回响应消息</returns>
        public override string ToXml()
        {
            XmlDocument doc = CreateXmlDocument();
            XmlElement root = doc.DocumentElement;
            XmlElement image = CreateXmlElement(doc, "Voice");
            image.AppendChild(CreateXmlElement(doc, "MediaId", MediaId));
            root.AppendChild(image);
            return doc.InnerXml;
        }
    }
}
