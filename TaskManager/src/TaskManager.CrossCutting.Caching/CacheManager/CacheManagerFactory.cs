using CacheManager.Core;
using System;

namespace TaskManager.CrossCutting.Caching.CacheManager
{
    public class CacheManagerFactory : ICacheManagerFactory
    {
        private readonly ICacheManager<object> _cache;
        public CacheManagerFactory()
        {
            _cache = CacheFactory.Build( settings =>
            {
                settings.WithSystemRuntimeCacheHandle("Dictionary");
            });
        }

        public ICacheManager<object> GetCacheManager() => _cache;
    }
}
