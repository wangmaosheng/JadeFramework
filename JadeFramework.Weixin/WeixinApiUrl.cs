namespace JadeFramework.Weixin
{
    public class WeixinApiUrl
    {
        /// <summary>
        /// AccessToken请求地址（参数appid和secret）
        /// </summary>
        public const string AccessToken = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

    }
}
