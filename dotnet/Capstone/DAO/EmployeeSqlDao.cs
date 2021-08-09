﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Capstone.Models;


namespace Capstone.DAO
{
    public class EmployeeSqlDao : IEmployeeDao
    {
        private readonly string connectionString;
        public EmployeeSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Employee> GetEmployeesByLandlordId(int id)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT u.user_id, u.username, u.email_address FROM users u " +
                        "JOIN employees_landlords el ON el.employee_id = u.user_id WHERE el.landlord_id = @landlord_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@landlord_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add(GetEmployeeFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return employees;
        }

        public int AddEmployee(Employee employee)
        {
            int employeeNumber = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO employees_landlords(landlord_id, employee_id)" + 
                                    "OUTPUT INSERTED.employee_id " + 
                                    "VALUES(@landlord_id, @employee_id);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@landlord_id", employee.LandlordIds);
                    cmd.Parameters.AddWithValue("@employee_id", employee.EmployeeId);

                    employeeNumber = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return employeeNumber;
        }

        public int DeleteEmployee(int id)
        {
            int success = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM employees_landlords " +
                                    "WHERE employee_id = @employee_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", id);
                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return success;
        }


        public Employee GetEmployeeFromReader(SqlDataReader reader)
        {
            Employee e = new Employee()
            {
                EmployeeId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                EmailAddress = Convert.ToString(reader["email_address"])
            };

            return e;
        }
    
}
}
