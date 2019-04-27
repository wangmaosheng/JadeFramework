using Newtonsoft.Json;
using System;

namespace JadeFramework.WorkFlow
{
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
        System,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom
    }
}
