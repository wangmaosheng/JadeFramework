namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// TOKEN返回响应
    /// </summary>
    public class ResponseToken
    {
        /// <summary>
        /// token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public int expires_in { get; set; }

        public string token_type { get; set; }
    }
}
