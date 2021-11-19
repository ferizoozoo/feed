using System;

namespace feed.Infrastructure.Cache.Interfaces
{
    public interface ICacheProvider
    {
        T Get<T>(string cacheKey);
        void Set<T>(string cacheKey, T cacheValue, int? expirationOffsetInSeconds);
        void Clear(string cacheKey);
    }
}