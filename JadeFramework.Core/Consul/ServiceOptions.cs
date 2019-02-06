namespace JadeFramework.Core.Consul
{
    public class ServiceOptions
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string GetUrl()
        {
            return $"http://{Address}:{Port}";
        }
    }
}
