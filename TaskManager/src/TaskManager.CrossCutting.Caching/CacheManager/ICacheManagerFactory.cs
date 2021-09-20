using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.CrossCutting.Caching.CacheManager
{
    public interface ICacheManagerFactory
    {
        ICacheManager<object> GetCacheManager();
    }
}
