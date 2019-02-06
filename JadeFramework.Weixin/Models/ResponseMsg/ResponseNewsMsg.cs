using JadeFramework.Weixin.Enums;
using System.Collections.Generic;
using System.Xml;

namespace JadeFramework.Weixin.Models.ResponseMsg
{
    /// <summary>
    /// 图文回复实体
    /// </summary>
    public class ResponseNewsMsg : ResponseRootMsg
    {
        /// <summary>
        /// 
        /// </summary>
        public override ResponseMsgType MsgType => ResponseMsgType.News;

        /// <summary>
        /// 获取或设置图文列表
        /// </summary>
        public List<Article> Articles { get; set; }

        /// <summary>
        /// 返回XML格式的响应消息
        /// </summary>
        /// <returns>返回响应消息</returns>
        public override string ToXml()
        {
            XmlDocument doc = CreateXmlDocument();
            XmlElement root = doc.DocumentElement;
            root.AppendChild(CreateXmlElement(doc, "ArticleCount", Articles != null ? Articles.Count : 0));
            XmlElement articles = CreateXmlElement(doc, "Articles");
            if (Articles != null && Articles.Count > 0)
            {
                foreach (Article article in Articles)
                    articles.AppendChild(article.ToXmlElement(doc));
            }
            root.AppendChild(articles);
            return doc.InnerXml;
        }
    }

    /// <summary>
    /// 图文实体
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 获取或设置标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置图片链接（尺寸建议：较好的效果为大图360*200，小图200*200）
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 获取或设置跳转链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 返回XmlElement
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <returns></returns>
        public XmlElement ToXmlElement(XmlDocument doc)
        {
            XmlElement item = doc.CreateElement("item");
            XmlElement title = doc.CreateElement("Title");
            title.AppendChild(doc.CreateCDataSection(Title ?? ""));
            item.AppendChild(title);
            XmlElement description = doc.CreateElement("Description");
            description.AppendChild(doc.CreateCDataSection(Description ?? ""));
            item.AppendChild(description);
            XmlElement picurl = doc.CreateElement("PicUrl");
            picurl.AppendChild(doc.CreateCDataSection(PicUrl ?? ""));
            item.AppendChild(picurl);
            XmlElement url = doc.CreateElement("Url");
            url.AppendChild(doc.CreateCDataSection(Url ?? ""));
            item.AppendChild(url);
            return item;
        }
    }
}
