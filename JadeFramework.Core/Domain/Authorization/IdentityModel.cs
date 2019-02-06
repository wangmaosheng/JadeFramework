namespace JadeFramework.Core.Domain.Authorization
{
    public class IdentityModel
    {
        public string scopes { get; set; } 
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}
