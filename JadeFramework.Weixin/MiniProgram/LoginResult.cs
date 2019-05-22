using Newtonsoft.Json;

namespace JadeFramework.Weixin.MiniProgram
{
    public enum MiniProgramResultCode
    {
        /// <summary>
        /// 未注册
        /// </summary>
        unregistered = 10000,
        /// <summary>
        /// 正常
        /// </summary>
        ok = 0,
        /// <summary>
        /// 系统内部错误
        /// </summary>
        error = 1
    }
    public abstract class MiniProgramResult
    {
        [JsonProperty("code")]
        public MiniProgramResultCode StatusCode { get; set; }
    }
}
