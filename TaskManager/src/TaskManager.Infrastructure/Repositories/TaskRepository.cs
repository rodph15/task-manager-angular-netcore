using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.CrossCutting.Caching.CacheManager;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : Repository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(ICacheManagerFactory cacheManagerFactory) : base(cacheManagerFactory)
        {
        }

        public async Task<bool> IsCompleted(string name)
        {
            bool completed = false;

            await Task.Run(() =>
            {
                if (GetAll().Where(x => x.Name.Equals(name) && x.Status == (int) StatusEnum.Completed).Any())
                    completed = true;
            });

            return completed;
        }

        public async Task<bool> NameExists(string name)
        {
            
            bool exists = false;

            var tasks = GetAll();

            if (tasks == null) return exists;

            await Task.Run(() =>
            {
                if (tasks.Where(x => x.Name.Equals(name)).Any())
                    exists = true;
            });

            return exists;

        }
    }
}
