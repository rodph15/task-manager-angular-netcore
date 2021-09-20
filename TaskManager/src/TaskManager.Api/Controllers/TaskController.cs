using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Service.Dtos;
using TaskManager.Service.Interfaces;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDto taskDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var (message, task) = await _taskService.CreateTask(taskDto);

                    return Created(message, task);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskDto taskDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var message = await _taskService.UpdateTask(taskDto);

                    return Ok(message);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteTask(string name)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var message = await _taskService.DeleteTask(name);

                    return Ok(message);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetTask(string name)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _taskService.FindTaskByName(name);

                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tasks = await _taskService.GetAll();

                    return Ok(tasks);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
