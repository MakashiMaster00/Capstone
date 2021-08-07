﻿using System;
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

        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT t.task_id, t.employee_id, t.date_entered, t.date_scheduled, t.is_urgent, " +
                        "t.task_description, t.property_id, t.task_status, p.landlord_id FROM tasks t " +
                        "JOIN properties p ON t.property_id = p.property_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
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
                    string sql = "SELECT task_id, employee_id, date_entered, date_scheduled, is_urgent, " +
                    "task_description, property_id, task_status, task_id " +
                    "FROM tasks " +
                    "WHERE task_id = @task_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@task_id", id);
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
                    string sql = "INSERT INTO tasks (property_id, is_urgent, task_description, task_status) " +
                        "OUTPUT INSERTED.task_id " +
                        "VALUES(@property_id, @is_urgent, @task_description, 'Pending')";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@property_id", task.PropertyId);
                    cmd.Parameters.AddWithValue("@is_urgent", task.IsUrgent);
                    cmd.Parameters.AddWithValue("@task_description", task.TaskDescription);

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
                        "is_urgent = @is_urgent, date_scheduled = @date_scheduled, task_status = @task_status;";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", task.EmployeeId);
                    cmd.Parameters.AddWithValue("@is_urgent", task.IsUrgent);
                    cmd.Parameters.AddWithValue("@date_scheduled", task.DateScheduled);
                    cmd.Parameters.AddWithValue("@task_status", task.TaskStatus);

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
                TaskId = Convert.ToInt32(reader["task_id"]),
                PropertyId = Convert.ToInt32(reader["property_id"]),
                IsUrgent = Convert.ToBoolean(reader["is_urgent"]),
                TaskDescription = Convert.ToString(reader["task_description"]),
                DateEntered = Convert.ToString(reader["date_entered"]),
                TaskStatus = Convert.ToString(reader["task_status"]),
                LandlordId = Convert.ToInt32(reader["landlord_id"])
            };
            if (!reader.IsDBNull(1))
            {
                t.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            }
            if (!reader.IsDBNull(3))
            {
                t.DateScheduled = Convert.ToString(reader["date_scheduled"]);
            }
            return t;
        }
    }
}