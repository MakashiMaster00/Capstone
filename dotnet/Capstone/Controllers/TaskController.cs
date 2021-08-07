using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;


namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskDao taskDao;

        public TaskController(ITaskDao _taskDao)
        {
            taskDao = _taskDao;
        }

        [HttpGet]
        public ActionResult<List<Task>> GetTasks()
        {
            List<Task> tasks = taskDao.GetTasks();

            if (tasks.Count != 0)
            {
                return Ok(tasks);
            }
            else
            {
                return BadRequest(new { message = "No tasks found" });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTask(int id)
        {
            Task task = taskDao.GetTask(id);

            if (task != null)
            {
                return Ok(task);
            }
            else
            {
                return BadRequest(new { message = "No task associated with that id." });
            }
        }

        [HttpPost]
        public ActionResult<int> AddTask(Task task)
        {
            int taskId = taskDao.AddTask(task);

            if (taskId != 0)
            {
                return Ok(taskId);
            }
            else
            {
                return BadRequest(new { message = "Task not successfully created." });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Task task, int id)
        {
            int successStatus = 0;

            if (task.TaskId == id)
            {
                successStatus = taskDao.UpdateTask(task);
            }
            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Task not successfully updated." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            int successStatus = 0;

            successStatus = taskDao.DeleteTask(id);

            if (successStatus == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Task not successfully deleted." });
            }
        }
    }
}

