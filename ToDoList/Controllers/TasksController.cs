using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ToDoList.Interfaces;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("Tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ILogger<TasksController> _logger;
        private readonly ITasksDal _tasksDal;

        public TasksController(ILogger<TasksController> logger, ITasksDal tasksDal)
        {
           _logger = logger;
           _tasksDal = tasksDal;
        }

        
        [Route("getTasks")]
        [HttpPost]
        public IActionResult GetTasks()
        {
            try
            {
                _logger.LogDebug($"***************** Start GetTasks ****************" );
                List<TaskItem> tasks = _tasksDal.GetAllTasks();
                _logger.LogDebug($"***************** Done GetTasks ****************");
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"GetTasks ERROR: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [Route("deleteTask")]
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _logger.LogDebug($"***************** Start DeleteTask ****************" +
                    $" Task Id: {id}");
                _tasksDal.DeleteTaskById(id);
                _logger.LogDebug($"***************** Done DeleteTask ****************" +
                    $" Task Id: {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"DeleteTask ERROR: {ex.Message}, TaskId: {id}");
                return BadRequest(ex.Message);
            }
        }

        [Route("updateTask")]
        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            try
            {
                _logger.LogDebug($"***************** Start UpdateTask ****************" +
                    $" Task Id: {id}");
                _tasksDal.UpdateTaskById(id);
                _logger.LogDebug($"***************** Done UpdateTask ****************" +
                    $" Task Id: {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"UpdateTask ERROR: {ex.Message}, TaskId: {id}");
                return BadRequest(ex.Message);
            }
        }

        [Route("addTask")]
        [HttpPost]
        public IActionResult AddTask(TaskItem taskItem)
        {
            try
            {
                _logger.LogDebug($"***************** Start AddTask ****************" +
                    $" Task: {taskItem.Name}");
                taskItem.Status = 0;
                taskItem.CreatedAt = DateTime.Now;
                _tasksDal.AddTask(taskItem);
                _logger.LogDebug($"***************** Done AddTask ****************" +
                    $" Task: {taskItem}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"AddTask ERROR: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
