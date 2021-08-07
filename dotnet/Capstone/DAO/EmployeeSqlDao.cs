using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Capstone.DAO
{
    public class EmployeeSqlDao : IEmployeeSqlDao
    {
        private readonly string connectionString;
        public EmployeeSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Task> GetEmployeesByLandlordId(int id)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT t.employee_id, t.task_id,t.property_id,t.task_description,t.date_entered,t.date_scheduled,t.task_status,p.landlord_id " +
                                "FROM tasks t " +
                                "JOIN properties p on t.property_id = p.property_id " +
                                "WHERE p.landlord_id = @landlord_id; ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@landlord_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return tasks;
        }

    }
}
