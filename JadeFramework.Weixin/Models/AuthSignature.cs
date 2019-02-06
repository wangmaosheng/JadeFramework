namespace JadeFramework.Weixin.Models
{
    /// <summary>
    /// 签名验证实体
    /// </summary>
    public class AuthSignature
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string EchoStr { get; set; }
    }
}
