using JadeFramework.Core.Extensions;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JadeFramework.Core.Security
{
    public class TokenProvider
    {
        public static bool Check(string token)
        {
            return true;
        }

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <param name="nonceStr"></param>
        /// <returns></returns>
        public static string CreateToken(string appkey, string appsecret, string nonceStr = null)
        {
            nonceStr = nonceStr ?? nonceStr.CreateNonce();
            string timestamp = DateTime.Now.ToTimeStamp().ToString();
            var arr = new[] { appkey, appsecret, nonceStr, timestamp }.OrderBy(m => m).ToArray();
            string arrStr = string.Join("", arr);
            var sha1 = SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrStr));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            return enText.ToString();
        }

    }
}
