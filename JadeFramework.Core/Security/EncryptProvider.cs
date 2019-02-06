using System;
using System.Security.Cryptography;
using System.Text;

namespace JadeFramework.Core.Security
{
    /// <summary>
    /// 加密
    /// </summary>
    public class EncryptProvider
    {
        /// <summary>
        /// 创建sha1加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CreateSha1Code(string str)
        {
            var sha1 = SHA1.Create();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(str);
            var hash = sha1.ComputeHash(dataToHash);
            string res = BitConverter.ToString(hash).Replace("-", "");
            return res;
        }
    }
}
