namespace JadeFramework.Weixin.Models
{
    public class AccessToken
    {
        /// <summary>
        /// accesstoken
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { get; set; }
    }
}
