using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.DAO
{
    public interface ITaskDao
    {
        List<Task> GetTasks(int id);
        Task GetTask(int id);
        int AddTask(Task task);
        int UpdateTask(Task task);
        int DeleteTask(int id);
    }
}
