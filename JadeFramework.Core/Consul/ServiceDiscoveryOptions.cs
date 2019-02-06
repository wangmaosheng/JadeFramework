namespace JadeFramework.Core.Consul
{
    public class ServiceDiscoveryOptions
    {
        public ServiceOptions Service { get; set; }
        public string UserServiceName { get; set; }

        public ConsulOptions Consul { get; set; }
    }
}
