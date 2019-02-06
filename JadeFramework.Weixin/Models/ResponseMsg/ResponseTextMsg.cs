using JadeFramework.Weixin.Enums;
using System.Xml;

namespace JadeFramework.Weixin.Models.ResponseMsg
{
    /// <summary>
    /// 回复文本信息
    /// </summary>
    public class ResponseTextMsg: ResponseRootMsg
    {
        /// <summary>
        /// 文本信息
        /// </summary>
        public override ResponseMsgType MsgType => ResponseMsgType.Text;

        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 返回XML格式的响应消息
        /// </summary>
        /// <returns>返回响应消息</returns>
        public override string ToXml()
        {
            XmlDocument doc = CreateXmlDocument();
            XmlElement root = doc.DocumentElement;
            root.AppendChild(CreateXmlElement(doc, "Content", Content));
            return doc.InnerXml;
        }
    }
}
