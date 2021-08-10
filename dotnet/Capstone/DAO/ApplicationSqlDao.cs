using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ApplicationSqlDao
    {
        private readonly string connectionString;
        public ApplicationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void GetApplications(int landlordId)
        {
            Application app = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT property_id, name, email, tenants, move_in_date, income, status " +
                                 "FROM applications " +
                                 "WHERE landlord_id = @landlordId";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
