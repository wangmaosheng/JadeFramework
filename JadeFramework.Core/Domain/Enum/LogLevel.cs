using System.ComponentModel;

namespace JadeFramework.Core.Domain.Enum
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 细微
        /// </summary>
        [Description("Trace")]
        Trace,
        /// <summary>
        /// 调试
        /// </summary>
        [Description("Debug")]
        Debug,
        /// <summary>
        /// 信息
        /// </summary>
        [Description("Info")]
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("Warn")]
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("Error")]
        Error,
        /// <summary>
        /// 严重
        /// </summary>
        [Description("Fatal")]
        Fatal,
        /// <summary>
        /// 无
        /// </summary>
        [Description("Off")]
        Off,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("Login")]
        Login
    }
}
