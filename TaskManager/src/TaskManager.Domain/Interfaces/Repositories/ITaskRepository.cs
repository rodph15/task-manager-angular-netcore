using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        Task<bool> NameExists(string name);
        Task<bool> IsCompleted(string name);
    }
}
