using System.ComponentModel;

namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 会签方式
    /// </summary>
    public enum ChatType
    {
        /// <summary>
        /// 并行
        /// </summary>
        [Description("并行")]
        Parallel = 0,
        /// <summary>
        /// 串行
        /// </summary>
        [Description("串行")]
        Serial = 1
    }

    /// <summary>
    /// 会签数据
    /// </summary>
    public class ChatData
    {
        /// <summary>
        /// 会签类型
        /// </summary>
        public ChatType ChatType { get; set; }

        /// <summary>
        /// 会签计算方式
        /// </summary>
        public ChatParallelCalcType ParallelCalcType { get; set; }
    }

    /// <summary>
    /// 会签并行计算方式
    /// </summary>
    public enum ChatParallelCalcType
    {
        /// <summary>
        /// 百分百
        /// </summary>
        [Description("百分百")]
        OneHundredPercent = 0,
        /// <summary>
        /// 超过一半
        /// </summary>
        [Description("超过一半")]
        MoreThenHalf = 1,
    }

}
