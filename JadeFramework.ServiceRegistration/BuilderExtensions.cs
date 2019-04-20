namespace Microsoft.AspNetCore.Builder
{
    using Consul;
    using JadeFramework.Core.Consul;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.Server.Features;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Extensions.Options;
    using System;
    using System.Linq;

    /// <summary>
    /// Consul 中间件扩展
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseServiceRegistration(this IApplicationBuilder app, ServiceCheckOptions checkOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            var lifetime = app.ApplicationServices.GetService(typeof(IApplicationLifetime)) as IApplicationLifetime;

            var serviceOptions = app.ApplicationServices.GetService(typeof(IOptions<ServiceDiscoveryOptions>)) as IOptions<ServiceDiscoveryOptions>;
            var consul = app.ApplicationServices.GetService(typeof(IConsulClient)) as IConsulClient;

            lifetime.ApplicationStarted.Register(() =>
            {
                OnStart(app, serviceOptions.Value, consul, lifetime, checkOptions);
            });
            lifetime.ApplicationStopped.Register(() =>
            {
                OnStop(app, serviceOptions.Value, consul, lifetime);
            });

            return app;
        }
        private static void OnStop(IApplicationBuilder app, ServiceDiscoveryOptions serviceOptions, IConsulClient consul, IApplicationLifetime lifetime)
        {

            var features = app.Properties["server.Features"] as FeatureCollection;
            var addresses = features.Get<IServerAddressesFeature>()
                .Addresses
                .Select(p => new Uri(p));

            foreach (var address in addresses)
            {
                var serviceId = $"{serviceOptions.Service.Name}_{address.Host}:{address.Port}";

                consul.Agent.ServiceDeregister(serviceId).GetAwaiter().GetResult();
            }

        }

        private static void OnStart(IApplicationBuilder app, ServiceDiscoveryOptions serviceOptions, IConsulClient consul, IApplicationLifetime lifetime, ServiceCheckOptions checkOptions)
        {

            var features = app.Properties["server.Features"] as FeatureCollection;
            var addresses = features.Get<IServerAddressesFeature>()
                .Addresses
                .Select(p => new Uri(p));

            foreach (var address in addresses)
            {
                var serviceId = $"{serviceOptions.Service.Name}_{address.Host}:{address.Port}";

                var httpCheck = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = serviceOptions.Service.DeregisterCriticalServiceAfter,
                    Interval = serviceOptions.Service.Interval,
                    HTTP = new Uri(address, checkOptions.HealthCheckUrl).OriginalString
                };

                var registration = new AgentServiceRegistration()
                {
                    Checks = new[] { httpCheck },
                    Address = address.Host,
                    ID = serviceId,
                    Name = serviceOptions.Service.Name,
                    Port = address.Port
                };

                consul.Agent.ServiceRegister(registration).GetAwaiter().GetResult();
            }

        }
    }
}
