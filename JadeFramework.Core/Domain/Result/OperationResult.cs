namespace JadeFramework.Core.Domain.Result
{
    /// <summary>
    /// 操作结果类接口
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IOperationResult<TResult>
    {
        /// <summary>
        /// 获取或设置 操作结果
        /// </summary>
        TResult Result { get; set; }

        /// <summary>
        /// 获取或设置 执行消息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 获取或设置 操作状态
        /// </summary>
        OperationStatus Status { get; set; }
    }

    /// <summary>
    /// 操作结果类
    /// </summary>
    public class OperationResult<TResult> : IOperationResult<TResult>
    {
        /// <summary>
        /// 获取或设置 操作结果
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// 获取或设置 执行消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置 操作状态
        /// </summary>
        public OperationStatus Status { get; set; }
    }

    /// <summary>
    /// 操作状态
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Success,

        /// <summary>
        /// 操作取消或操作没引发任何变化
        /// </summary>
        NoChanged,

        /// <summary>
        /// 参数错误
        /// </summary>
        ParamError,

        /// <summary>
        /// 指定参数的数据不存在
        /// </summary>
        QueryNull,

        /// <summary>
        /// 权限不足
        /// </summary>
        PurviewLack,

        /// <summary>
        /// 非法操作
        /// </summary>
        IllegalOperation,

        /// <summary>
        /// 警告
        /// </summary>
        Warning,

        /// <summary>
        /// 操作引发错误
        /// </summary>
        Error,
        /// <summary>
        /// 程序异常
        /// </summary>
        Exception
    }
}