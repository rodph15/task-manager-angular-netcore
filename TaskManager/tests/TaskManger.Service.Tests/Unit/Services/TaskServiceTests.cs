using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.CrossCutting.Configuration.Configurations;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Service.Dtos;
using TaskManager.Service.Interfaces;
using TaskManager.Service.Services;
using Xunit;

namespace TaskManger.Service.Tests.Unit.Services
{
    public class TaskServiceTests
    {
        private Mock<ITaskRepository> _taskRepositoryMock;
        private IMapper _mapper;

        public TaskServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);
        }

        [Fact]
        public async Task CreateTask_save_should_return_message_and_object()
        {

            var taskDto = new TaskDto { Name = "Hello", Status = 1 };
            var task = new TaskEntity { Name = "Hello", Status = 1 };

            _taskRepositoryMock.Setup(x => x.Save(It.IsAny<TaskEntity>()));

            var service = new TaskService(_taskRepositoryMock.Object, _mapper);

            var result = await service.CreateTask(taskDto);

            var (message, taskCreated) = result;
            message.Should().NotBeNull();
            taskCreated.Should().NotBeNull();
            taskCreated.Should().BeEquivalentTo(taskDto);
        }

        [Fact]
        public async Task DeleteTask_delete_should_return_message()
        {

            var name = "Hello";
            var task = new TaskEntity { Name = "Hello", Status = 1 };
            var tasks = new List<TaskEntity> {
                new TaskEntity { Name = "Hello", Status = 1 },
                new TaskEntity { Name = "Hello2", Status = 1 }
            };

            _taskRepositoryMock.Setup(x => x.IsCompleted(It.IsAny<string>())).ReturnsAsync(true);
            _taskRepositoryMock.Setup(x => x.GetAll()).Returns(tasks);
            _taskRepositoryMock.Setup(x => x.Find(It.IsAny<Func<TaskEntity,bool>>())).Returns(task);

            var service = new TaskService(_taskRepositoryMock.Object, _mapper);

            var result = await service.DeleteTask(name);

            var contentResult = result;
            contentResult.Should().NotBeNull();
            contentResult.Should().BeEquivalentTo($"The task {name} has been deleted");

        }

        [Fact]
        public async Task FindTaskByName_find_should_return_object()
        {

            var name = "Hello";
            var task = new TaskEntity { Name = "Hello", Status = 1 };
            var tasks = new List<TaskEntity> {
                new TaskEntity { Name = "Hello", Status = 1 },
                new TaskEntity { Name = "Hello2", Status = 1 }
            };

            _taskRepositoryMock.Setup(x => x.GetAll()).Returns(tasks);
            _taskRepositoryMock.Setup(x => x.Find(It.IsAny<Func<TaskEntity, bool>>())).Returns(task);

            var service = new TaskService(_taskRepositoryMock.Object, _mapper);

            var result = await service.FindTaskByName(name);

            var contentResult = result;
            contentResult.Should().NotBeNull();
            contentResult.Should().BeEquivalentTo(task);

        }

        [Fact]
        public async Task GetAll_find_should_return_list()
        {

            
            var tasks = new List<TaskEntity> {
                new TaskEntity { Name = "Hello", Status = 1 },
                new TaskEntity { Name = "Hello2", Status = 1 }
            };

            _taskRepositoryMock.Setup(x => x.GetAll()).Returns(tasks);

            var service = new TaskService(_taskRepositoryMock.Object, _mapper);

            var result = await service.GetAll();

            var contentResult = result;
            contentResult.Should().NotBeNull();
            contentResult.Should().BeEquivalentTo(tasks);

        }

        [Fact]
        public async Task UpdateTask_update_should_return_message()
        {

            
            var task = new TaskDto { Name = "Hello", Status = 1 };

            _taskRepositoryMock.Setup(x => x.Update(It.IsAny<TaskEntity>(), It.IsAny<Func<TaskEntity, bool>>()));

            var service = new TaskService(_taskRepositoryMock.Object, _mapper);

            var result = await service.UpdateTask(task);

            var contentResult = result;
            contentResult.Should().NotBeNull();
            contentResult.Should().BeEquivalentTo($"The task {task.Name} has been updated");

        }

        [Fact]
        public async Task ValidateTask_validating_should_return_object()
        {


            var name = "Hello";
            var task = new TaskEntity { Name = "Hello", Status = 1 };
            var tasks = new List<TaskEntity> {
                new TaskEntity { Name = "Hello", Status = 1 },
                new TaskEntity { Name = "Hello2", Status = 1 }
            };

            _taskRepositoryMock.Setup(x => x.GetAll()).Returns(tasks);
            _taskRepositoryMock.Setup(x => x.Find(It.IsAny<Func<TaskEntity, bool>>())).Returns(task);

            var service = new TaskService(_taskRepositoryMock.Object, _mapper);

            var result = await service.ValidateTask(name);

            var contentResult = result;
            contentResult.Should().NotBeNull();
            contentResult.Should().BeEquivalentTo(task);

        }
    }
}

