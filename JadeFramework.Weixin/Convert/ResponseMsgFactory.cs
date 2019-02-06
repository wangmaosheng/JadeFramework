//using System;
//using System.IO;
//using System.Xml.Linq;
//using System.Xml.Serialization;
//using Framework.Weixin.Enums;
//using Framework.Weixin.Models.ResponseMsg;

//namespace JadeFramework.Weixin.Convert
//{
//    public static class ResponseMsgFactory
//    {
//        /// <summary>
//        /// 将响应的消息转换成XML
//        /// </summary>
//        /// <param name="response"></param>
//        /// <returns></returns>
//        public static XDocument ConvertXDocument(ResponseRootMsg response)
//        {
//            XDocument document = null;
//            switch (response.MsgType)
//            {
//                case ResponseMsgType.Text:
//                    document = ParseDocument(typeof (ResponseTextMsg), (ResponseTextMsg) response);
//                    break;
//            }
//            return document;
//        }

//        public static XDocument ParseDocument(Type objType, object obj)
//        {
//            MemoryStream memoryStream = new MemoryStream();
//            XmlSerializer serializer = new XmlSerializer(objType);
//            serializer.Serialize(memoryStream, obj);
//            memoryStream.Position = 0;
//            StreamReader sr = new StreamReader(memoryStream);
//            string str = sr.ReadToEnd();
//            sr.Dispose();
//            memoryStream.Dispose();
//            return XDocument.Parse(str);
//        }
//    }
//}
