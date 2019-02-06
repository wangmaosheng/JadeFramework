using System;
using Newtonsoft.Json;

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

        [JsonProperty("dash")]
        public bool Dash { get; set; }
    }
}
