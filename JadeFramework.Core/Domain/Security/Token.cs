namespace JadeFramework.Core.Domain.Security
{
    public class Token
    {
        /// <summary>
        /// accesstoken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpriesIn { get; set; }
    }
}
