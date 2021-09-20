using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Api.Controllers;
using TaskManager.Domain.Entities;
using TaskManager.Service.Dtos;
using TaskManager.Service.Interfaces;
using Xunit;

namespace TaskManager.Api.Tests.Unit.Controllers
{
    public class TaskControllerTests
    {
        private Mock<ITaskService> _taskServiceMock;

        public TaskControllerTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
        }

        [Fact]
        public async Task CreateTask_post_should_return_created()
        {

            var taskDto = new TaskDto { Name = "Hello", Status = 1 };

            _taskServiceMock.Setup(x => x.CreateTask(It.IsAny<TaskDto>())).ReturnsAsync(($"The task {taskDto.Name} has been created", taskDto));

            var controller = new TaskController(_taskServiceMock.Object);

            var result = await controller.CreateTask(taskDto);

            var contentResult = result as CreatedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"The task {taskDto.Name} has been created");

        }

        [Fact]
        public async Task UpdateTask_put_should_return_ok()
        {

            var taskDto = new TaskDto { Name = "Hello", Status = 1 };

            _taskServiceMock.Setup(x => x.UpdateTask(It.IsAny<TaskDto>())).ReturnsAsync($"The task {taskDto.Name} has been updated");

            var controller = new TaskController(_taskServiceMock.Object);

            var result = await controller.UpdateTask(taskDto);

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult.Value.Should().BeEquivalentTo($"The task {taskDto.Name} has been updated");

        }

        [Fact]
        public async Task DeleteTask_delete_should_return_ok()
        {

            var name = "Hello";

            _taskServiceMock.Setup(x => x.DeleteTask(It.IsAny<string>())).ReturnsAsync($"The task {name} has been deleted");

            var controller = new TaskController(_taskServiceMock.Object);

            var result = await controller.DeleteTask(name);

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult.Value.Should().BeEquivalentTo($"The task {name} has been deleted");

        }

        [Fact]
        public async Task GetTask_getByName_should_return_ok()
        {

            var name = "Hello";
            var task = new TaskEntity { Name = "Hello", Status = 1 };

            _taskServiceMock.Setup(x => x.FindTaskByName(It.IsAny<string>())).ReturnsAsync(task);

            var controller = new TaskController(_taskServiceMock.Object);

            var result = await controller.GetTask(name);

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult.Value.Should().BeEquivalentTo(task);

        }

        [Fact]
        public async Task GetTasks_getAll_should_return_ok()
        {

            var tasks = new List<TaskEntity> {
                new TaskEntity { Name = "Hello", Status = 1 },
                new TaskEntity { Name = "Hello2", Status = 1 }
            };

            _taskServiceMock.Setup(x => x.GetAll()).ReturnsAsync(tasks);

            var controller = new TaskController(_taskServiceMock.Object);

            var result = await controller.GetTasks();

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult.Value.Should().BeEquivalentTo(tasks);

        }

    }
}
