using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace JadeFramework.Core.Helper
{
    /// <summary>
    /// XML帮助类
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// 序列化将流转成XML字符串
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns></returns>
        public static XDocument Convert(Stream stream)
        {
            return XDocument.Load(stream);
        }
    }
}