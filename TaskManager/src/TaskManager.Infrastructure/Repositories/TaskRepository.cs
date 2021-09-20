using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.CrossCutting.Caching.CacheManager;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : Repository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(ICacheManagerFactory cacheManagerFactory) : base(cacheManagerFactory)
        {
        }
    }
}
