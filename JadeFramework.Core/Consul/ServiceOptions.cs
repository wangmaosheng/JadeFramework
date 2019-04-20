namespace JadeFramework.Core.Consul
{
    using System;
    public class ServiceOptions
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string GetUrl()
        {
            return $"http://{Address}:{Port}";
        }

        /// <summary>
        /// 间隔
        /// 默认10秒一次
        /// </summary>
        public int Interval { get; set; } = 10;
    }
}
