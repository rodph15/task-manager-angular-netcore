using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.CrossCutting.ExceptionManager.Exceptions;
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

        public async Task<(string message, TaskDto entity)> CreateTask(TaskDto taskDto)
        {
            if (await _taskRepository.NameExists(taskDto.Name))
                throw new TaskNameAlreadyExistsException();

            await Task.Run(() => _taskRepository.Save(_mapper.Map<TaskEntity>(taskDto)));

            return ($"The task {taskDto.Name} has been created", taskDto);
        }

        public async Task<string> DeleteTask(string taskName)
        {
            await ValidateTask(taskName);

            if (!await _taskRepository.IsCompleted(taskName))
                throw new TaskStatusIsNotCompleted();

            await Task.Run(() => _taskRepository.Delete(x => x.Name == taskName));

            return $"The task {taskName} has been deleted";
        }

        public async Task<TaskEntity> FindTaskByName(string taskName)
        {
            return await ValidateTask(taskName);
        }

        public async Task<IEnumerable<TaskEntity>> GetAll() => await Task.Run(() => _taskRepository.GetAll());

        public async Task<string> UpdateTask(TaskDto taskDto)
        {
            await Task.Run(() => _taskRepository.Update(_mapper.Map<TaskEntity>(taskDto), x => x.Name == taskDto.Name));

            return $"The task {taskDto.Name} has been updated";
        }

        private async Task<TaskEntity> ValidateTask(string taskName)
        {
            if (await Task.Run(() => _taskRepository.GetAll()) == null)
                throw new TaskNotFoundException();

            var task = await Task.Run(() => _taskRepository.Find(x => x.Name == taskName));

            if (task == null)
                throw new TaskNotFoundException();

            return task;
        }
    }
}
