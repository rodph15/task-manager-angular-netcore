using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Service.Dtos;

namespace TaskManager.Service.Interfaces
{
    public interface ITaskService
    {
        Task<(string message, TaskDto entity)> CreateTask(TaskDto taskDto);

        Task<string> UpdateTask(TaskDto taskDto);
        Task<string> DeleteTask(string taskName);

        Task<TaskEntity> FindTaskByName(string taskName);

        Task<IEnumerable<TaskEntity>> GetAll();
    }
}
