using JadeFramework.Weixin.Enums;
using System.Xml;

namespace JadeFramework.Weixin.Models.ResponseMsg
{
    /// <summary>
    /// 响应消息基本实体接口
    /// （用于消息转换）
    /// </summary>
    public interface IResponseRootMsg
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        long CreateTime { get; set; }
    }

    /// <summary>
    /// 响应消息基本实体
    /// </summary>
    public class ResponseRootMsg: IResponseRootMsg
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息枚举类型
        /// </summary>
        public virtual ResponseMsgType MsgType { get; set; }


        protected virtual XmlDocument CreateXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("xml");
            doc.AppendChild(root);
            root.AppendChild(CreateXmlElement(doc, "ToUserName", ToUserName));
            root.AppendChild(CreateXmlElement(doc, "FromUserName", FromUserName));
            root.AppendChild(CreateXmlElement(doc, "CreateTime", CreateTime));
            root.AppendChild(CreateXmlElement(doc, "MsgType", MsgType));
            return doc;
        }

        /// <summary>
        /// 创建XmlElement节点。
        /// 注：不包含数据。
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <param name="name">子节点名称</param>
        /// <returns></returns>
        protected XmlElement CreateXmlElement(XmlDocument doc, string name)
        {
            return doc.CreateElement(name);
        }

        /// <summary>
        /// 创建XmlElement节点。
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <param name="name">子节点名称</param>
        /// <param name="data">子节点包含的数据</param>
        protected virtual XmlElement CreateXmlElement(XmlDocument doc, string name, string data)
        {
            return CreateXmlElement(doc, name, data, XmlNodeType.CDATA);
        }
        /// <summary>
        /// 创建XmlElement节点。
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <param name="name">子节点名称</param>
        /// <param name="data">子节点包含的数据</param>
        protected virtual XmlElement CreateXmlElement(XmlDocument doc, string name, ResponseMsgType data)
        {
            return CreateXmlElement(doc, name, data.ToString("g"), XmlNodeType.CDATA);
        }
        /// <summary>
        /// 创建XmlElement节点。
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <param name="name">子节点名称</param>
        /// <param name="data">子节点包含的数据</param>
        protected virtual XmlElement CreateXmlElement(XmlDocument doc, string name, long data)
        {
            return CreateXmlElement(doc, name, data.ToString(), XmlNodeType.Text);
        }
        /// <summary>
        /// 创建XmlElement节点。
        /// 注：仅支持CDATA和Text类型的数据。
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <param name="name">子节点名称</param>
        /// <param name="data">子节点包含的数据</param>
        /// <param name="dataType">子节点数据的类型</param>
        protected virtual XmlElement CreateXmlElement(XmlDocument doc, string name, string data, XmlNodeType dataType)
        {
            XmlElement elem = doc.CreateElement(name);
            if (dataType == XmlNodeType.CDATA)
                elem.AppendChild(doc.CreateCDataSection(data));
            else if (dataType == XmlNodeType.Text)
                elem.AppendChild(doc.CreateTextNode(data));
            return elem;
        }

        /// <summary>
        /// 返回XML格式的响应消息
        /// </summary>
        /// <returns>返回响应消息</returns>
        public virtual string ToXml()
        {
            return CreateXmlDocument().InnerXml;
        }
    }
}
