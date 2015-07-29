using System;
using System.Runtime.Caching;

namespace Example.CrossCutting.Caching.Default
{
    internal class DefaultCache : ICache
    {
        private readonly MemoryCache _cache;

        public DefaultCache()
        {
            _cache = new MemoryCache(GetType().FullName);
        }

        public bool Contains(object key)
        {
            return _cache.Contains(ToCacheKey(key));
        }

        public object Get(object key)
        {
            return _cache.Get(ToCacheKey(key));
        }

        public void Remove(object key)
        {
            _cache.Remove(ToCacheKey(key));
        }

        public void Set(object key, object value)
        {
            _cache.Add(ToCacheKey(key), value, new CacheItemPolicy() { });
        }

        private static String ToCacheKey(Object key)
        {
            return key.ToString();
        }

        public void Dispose()
        {
            _cache.Dispose();
        }
    }
}
