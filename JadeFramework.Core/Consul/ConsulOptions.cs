namespace JadeFramework.Core.Consul
{
    /// <summary>
    /// Consul Options
    /// </summary>
    public class ConsulOptions
    {
        public string HttpEndpoint { get; set; }

        public DnsEndpoint DnsEndpoint { get; set; }
    }
}
