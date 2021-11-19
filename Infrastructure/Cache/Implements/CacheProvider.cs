using System;
using Microsoft.Extensions.Caching.Memory;
using feed.Infrastructure.Cache.Interfaces;

namespace feed.Infrastructure.Cache.Implements
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IMemoryCache _cache;
        private const int defaultExpirationOffsetInSeconds = 20;

        public CacheProvider(IMemoryCache cache)
        {
            _cache = cache;    
        }

        public T Get<T>(string cacheKey)
        {
            _cache.TryGetValue(cacheKey, out T value);
            return value;
        }

        public void Set<T>(string cacheKey, T cacheValue, int? expirationOffsetInSeconds)
        {
            _cache.Set(
                cacheKey,
                cacheValue,
                DateTimeOffset.Now.AddSeconds(expirationOffsetInSeconds ?? defaultExpirationOffsetInSeconds)
                );
        }

        public void Clear(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
    }
}