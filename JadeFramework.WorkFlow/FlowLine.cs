namespace JadeFramework.WorkFlow
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 流程连线
    /// </summary>
    public class FlowLine
    {
        /// <summary>
        /// line id
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// "sl":直线,"lr":中段可左右移动的折线,"tb":中段可上下移动的折线
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// from node
        /// </summary>
        [JsonProperty("from")]
        public Guid From { get; set; }

        /// <summary>
        /// to node
        /// </summary>
        [JsonProperty("to")]
        public Guid To { get; set; }

        /// <summary>
        /// line name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 描边
        /// </summary>
        [JsonProperty("dash")]
        public bool Dash { get; set; }

        /// <summary>
        /// 属性值对象
        /// </summary>
        [JsonProperty("setInfo")]
        public FlowLineSetInfo SetInfo { get; set; }
    }
    /// <summary>
    /// 线条自定义信息
    /// </summary>
    public class FlowLineSetInfo
    {
        /// <summary>
        /// 线条ID
        /// </summary>
        [JsonProperty("lineId")]
        public Guid? LineId { get; set; }

        /// <summary>
        /// 线条类型
        /// </summary>
        [JsonProperty("lineType")]
        public FlowLineSetInfoType? LineType { get; set; }

        /// <summary>
        /// 自定义线条类型SQL
        /// </summary>
        [JsonProperty("customSQL")]
        public string CustomSQL { get; set; }
    }
    /// <summary>
    /// 线条类型
    /// </summary>
    public enum FlowLineSetInfoType
    {
        /// <summary>
        /// 系统通用
        /// </summary>
        [Description("系统通用")]
        System = 0,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")]
        Custom = 1,
        /// <summary>
        /// 自定义类型最终执行SQL
        /// 注：自定义的情况，因为系统无法区分流程的最终的流向，所以只能人为用SQL先判断出执行的结果，再有系统自动判断
        /// </summary>
        [Description("自定义类型最终执行SQL")]
        CustomResult = 2
    }
}
