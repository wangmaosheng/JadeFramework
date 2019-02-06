using System;

namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// 客户端token实体
    /// </summary>
    public class ClientToken
    {
        /// <summary>
        /// token
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public int Expires_In { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <param name="advanceSeconds">提前秒数</param>
        /// <returns></returns>
        public bool IsExpired(uint? advanceSeconds = 300)
        {
            if (advanceSeconds == null)
            {
                return this.CreateTime.AddSeconds(Expires_In) < DateTime.Now;
            }
            else
            {
                return this.CreateTime.AddSeconds(Expires_In).AddSeconds((double)advanceSeconds) < DateTime.Now;//提前五分钟过期
            }
        }
    }
}
