using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Service.Dtos;

namespace TaskManager.Service.Interfaces
{
    public interface ITaskService
    {
        Task<(string message, bool saved)> CreateTask(TaskDto taskDto);

        Task<IEnumerable<object>> GetAll();
    }
}
