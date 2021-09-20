using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TaskManager.CrossCutting.Caching.CacheManager;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ICacheManagerFactory _cacheManagerFactory;
        public Repository(ICacheManagerFactory cacheManagerFactory)
        {
            _cacheManagerFactory = cacheManagerFactory;

        }
        public void Save(TEntity entity)
        {
            var tasks = _cacheManagerFactory.GetCacheManager().Get("TaskList") as List<TEntity>;

            if (tasks == null)
                tasks = new List<TEntity>();

            tasks.Add(entity);

            _cacheManagerFactory.GetCacheManager().Put("TaskList", tasks);

        }
        public void Update(TEntity entity, Func<TEntity, bool> where)
        {
            var tasks = _cacheManagerFactory.GetCacheManager().Get("TaskList") as List<TEntity>;

            tasks.Remove(tasks.Where(where).First());
            tasks.Add(entity);

            _cacheManagerFactory.GetCacheManager().Put("TaskList", tasks);
        }
        public void Delete(Func<TEntity, bool> where)
        {
            var tasks = _cacheManagerFactory.GetCacheManager().Get("TaskList") as List<TEntity>;

            tasks.Remove(tasks.Where(where).First());

            _cacheManagerFactory.GetCacheManager().Put("TaskList", tasks);
        }

        public TEntity Find(Func<TEntity, bool> where)
        {
            var tasks = _cacheManagerFactory.GetCacheManager().Get("TaskList") as List<TEntity>;

            return tasks.Where(where).FirstOrDefault();
        }
        public IEnumerable<TEntity> GetAll() => _cacheManagerFactory.GetCacheManager().Get("TaskList") as List<TEntity>;

    }

}
