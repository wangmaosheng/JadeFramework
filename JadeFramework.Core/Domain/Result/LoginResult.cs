namespace JadeFramework.Core.Domain.Result
{
    /// <summary>
    /// 登录实体接口
    /// </summary>
    /// <typeparam name="TUser">返回实体类型</typeparam>
    public interface ILoginResult<TUser>
    {
        /// <summary>
        /// 返回实体
        /// </summary>
        TUser User { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 登录状态返回
        /// </summary>
        LoginStatus LoginStatus { get; set; }
    }

    /// <summary>
    /// 登录实体
    /// </summary>
    /// <typeparam name="TUser">返回实体类型</typeparam>
    public class LoginResult<TUser> : ILoginResult<TUser>
    {
        /// <summary>
        /// 返回实体
        /// </summary>
        public TUser User { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 登录状态返回
        /// </summary>
        public LoginStatus LoginStatus { get; set; }
    }

    /// <summary>
    /// 登录状态枚举
    /// </summary>
    public enum LoginStatus
    {
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        Error = 0,
        /// <summary>
        /// 登录成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 程序异常
        /// </summary>
        Exception = 2

    }
}
