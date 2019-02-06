using System;
using System.Threading.Tasks;

namespace JadeFramework.Cache
{
    public interface ICachingProvider
    {
        object Get(string cacheKey);
        TItem Get<TItem>(object key) where TItem : class;
        Task<object> GetAsync(string cacheKey);
        void Set(string cacheKey, object cacheValue);
        void Set(string cacheKey, object cacheValue, TimeSpan absoluteExpirationRelativeToNow);
        Task SetAsync(string cacheKey, object cacheValue, TimeSpan absoluteExpirationRelativeToNow);
    }
}
