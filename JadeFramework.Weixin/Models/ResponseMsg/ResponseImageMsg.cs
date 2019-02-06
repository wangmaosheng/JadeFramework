using JadeFramework.Weixin.Enums;
using System.Xml;

namespace JadeFramework.Weixin.Models.ResponseMsg
{
    /// <summary>
    /// 回复图片消息
    /// </summary>
    public class ResponseImageMsg : ResponseRootMsg
    {
        /// <summary>
        /// 图片消息
        /// </summary>
        public override ResponseMsgType MsgType => ResponseMsgType.Image;

        /// <summary>
        /// 通过素材管理中的接口上传多媒体文件，得到的id。
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
            XmlElement image = CreateXmlElement(doc, "Image");
            image.AppendChild(CreateXmlElement(doc, "MediaId", MediaId));
            root.AppendChild(image);
            return doc.InnerXml;
        }
    }
}
