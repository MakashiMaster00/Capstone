using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Capstone.Models;


namespace Capstone.DAO
{
    public class TaskSqlDao : ITaskDao
    {
        private readonly string connectionString;
        public TaskSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Task> GetTasks(int id)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT employee_id,task_id,property_id,is_urgent " +
                    "FROM tasks" +
                    "WHERE employee_id = @employee_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tasks.Add(GetTaskFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return tasks;
        }

        public Task GetTask(int id)
        {
            Task task = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT employee_id,task_id,property_id,is_urgent " +
                    "FROM tasks" +
                    "WHERE employee_id = @employee_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        task = GetTaskFromReader(reader);
                    }
                  
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return task;
        }
        

        public int AddTask(Task task)
        {
            int taskId = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO tasks (employee_id, task_id, property_id, is_urgent) " +
                        "OUTPUT INSERTED.task_id VALUES(@employee_id, " +
                        "@task_id, @property_id, @is_urgent)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", task.EmployeeId);
                    cmd.Parameters.AddWithValue("@task_id", task.TaskId);
                    cmd.Parameters.AddWithValue("@property", task.PropertyId);
                    cmd.Parameters.AddWithValue("@is_urgent", task.IsUrgent);


                    taskId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return taskId;
        }

        public int UpdateTask(Task task)
        {
            int success = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE tasks SET employee_id = @employee_id, " +
                        "task_id = @task_id, property_id = @property_id, is_urgent = @is_urgent";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", task.EmployeeId);
                    cmd.Parameters.AddWithValue("@task_id", task.TaskId);
                    cmd.Parameters.AddWithValue("@property", task.PropertyId);
                    cmd.Parameters.AddWithValue("@is_urgent", task.IsUrgent);

                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return success;
        }

        public int DeleteTask(int id)
        {
            int success = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE from tasks " +
                        "WHERE task_id = @task_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@task_id", id);
                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return success;
        }
        public Task GetTaskFromReader(SqlDataReader reader)
        {

            Task t = new Task()
            {
                EmployeeId = Convert.ToInt32(reader["employee_id"]),
                TaskId = Convert.ToInt32(reader["task_id"]),
                PropertyId = Convert.ToInt32(reader["property_id"]),
                IsUrgent = Convert.ToBoolean(reader["is_urgent"])

            };
            return t;
        }
    }
}
