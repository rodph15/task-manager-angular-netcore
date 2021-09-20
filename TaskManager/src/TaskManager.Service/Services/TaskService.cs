using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Service.Dtos;
using TaskManager.Service.Interfaces;

namespace TaskManager.Service.Services
{
    public class TaskService : ITaskService
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<(string message, bool saved)> CreateTask(TaskDto taskDto)
        {
            await Task.Run(() => _taskRepository.Save(_mapper.Map<TaskEntity>(taskDto)));

            return ("ok", true);
        }

        public async Task<IEnumerable<object>> GetAll() => await Task.Run(() => _taskRepository.GetAll());
        
    }
}
