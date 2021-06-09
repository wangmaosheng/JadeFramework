using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 请求中获取的对象都是同一个
    /// </summary>
    public interface IAutoDenpendencyScoped
    { }
    /// <summary>
    /// 获取的时候都是同一个实例
    /// </summary>
    public interface IAutoDenpendencySingleton
    { }
    /// <summary>
    /// 每次从容器中获取的时候都是一个新的实例
    /// </summary>
    public interface IAutoDenpendencyTransient
    { }
    /// <summary>
    /// 自动注入扩展
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注入数据
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddAutoDIService(this IServiceCollection services)
        {
            //var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            string path = AppContext.BaseDirectory;
            var referencedAssemblies = Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFrom).ToArray();
            Set(typeof(IAutoDenpendencyScoped), path, referencedAssemblies, services);
            Set(typeof(IAutoDenpendencySingleton), path, referencedAssemblies, services);
            Set(typeof(IAutoDenpendencyTransient), path, referencedAssemblies, services);
            return services;
        }

        private static void Set(Type iType, string path, Assembly[] referencedAssemblies, IServiceCollection services)
        {
            var types = referencedAssemblies
                .SelectMany(a => a.DefinedTypes)
                .Select(type => type.AsType())
                .Where(x => x != iType && iType.IsAssignableFrom(x)).ToArray();
            var implementTypes = types.Where(x => x.IsClass).ToArray();
            var interfaceTypes = types.Where(x => x.IsInterface).ToArray();
            foreach (var implementType in implementTypes)
            {
                var interfaceType = interfaceTypes.FirstOrDefault(x => x.IsAssignableFrom(implementType));
                if (interfaceType != null)
                {
                    switch (iType.Name)
                    {
                        case nameof(IAutoDenpendencyScoped):
                            services.AddScoped(interfaceType, implementType);
                            break;
                        case nameof(IAutoDenpendencyTransient):
                            services.AddTransient(interfaceType, implementType);
                            break;
                        case nameof(IAutoDenpendencySingleton):
                            services.AddSingleton(interfaceType, implementType);
                            break;
                    }
                }
                else
                {
                    switch (iType.Name)
                    {
                        case nameof(IAutoDenpendencyScoped):
                            services.AddScoped(implementType);
                            break;
                        case nameof(IAutoDenpendencyTransient):
                            services.AddTransient(implementType);
                            break;
                        case nameof(IAutoDenpendencySingleton):
                            services.AddSingleton(implementType);
                            break;
                    }
                }
            }
        }
    }

}
