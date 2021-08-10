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
        private readonly IEmployeeDao employeeDao;

        public TaskController(ITaskDao _taskDao, IEmployeeDao _employeeDao)
        {
            taskDao = _taskDao;
            employeeDao = _employeeDao;
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
        [HttpPut("{id}/status")]
        public IActionResult UpdateTaskStatus(Task task, int id)
        {
            int successStatus = 0;

            if (task.TaskId == id)
            {
                successStatus = taskDao.UpdateTaskStatus(task);
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

        [HttpGet("{id}/employees")]
        public ActionResult<List<Employee>> GetEmployees(int id)
        {
            List<Employee> employees = employeeDao.GetEmployeesByLandlordId(id);

            if (employees.Count != 0)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(new { message = "No employees found" });
            }
        }

        [HttpGet("{id}/employee/{employeeId}")]
        public ActionResult<Employee> GetEmployee(int employeeId)
        {
            Employee employee = employeeDao.GetEmployee(employeeId);

            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest(new { message = "Employee not found" });
            }
        }
        [HttpPost]
        public ActionResult<int> AddEmployee(Employee employee)
        {
            int employeeId = employeeDao.AddEmployee(employee);
            if (employeeId != 0)
            {
                return Ok(employeeId);
            }
            else
            {
                return BadRequest(new { message = "Employee not successfully created." });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            int successStatus = 0;

            successStatus = employeeDao.DeleteEmployee(id);

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

