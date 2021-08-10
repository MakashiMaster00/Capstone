using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ApplicationSqlDao : IApplicationDao
    {
        private readonly string connectionString;
        public ApplicationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Application> GetApplications(int landlordId)
        {
            List<Application> app = new List<Application>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT application_id, renter_id, landlord_id, property_id, name, email, tenants, move_in_date, income, status " +
                                 "FROM applications " +
                                 "WHERE landlord_id = @landlordId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@landlordId", landlordId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        app.Add(GetAppFromReader(reader));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return app;
        }

        public int AddApplication(Application app)
        {
            int propertyId = app.PropertyId;
            int landlordId = 0;
            int appId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlOne = "SELECT landlord_id FROM properties WHERE property_id = @propertyId";
                    SqlCommand cmdOne = new SqlCommand(sqlOne, conn);
                    cmdOne.Parameters.AddWithValue("@propertyId", propertyId);
                    SqlDataReader reader = cmdOne.ExecuteReader();
                    if (reader.Read())
                    {
                        landlordId = Convert.ToInt32(reader["landlord_id"]);
                    }
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlTwo = "INSERT INTO applications (renter_id, landlord_id, property_id, name, email, tenants, move_in_date, income, status) "+
                                    "OUTPUT INSERTED.application_id VALUES(@renter_id, @landlord_id, @property_id, @name, @email, @tenants, @move_in_date, @income, @status)";
                    SqlCommand cmdTwo = new SqlCommand(sqlTwo, conn);
                    cmdTwo.Parameters.AddWithValue("@renter_id", app.RenterId);
                    cmdTwo.Parameters.AddWithValue("@landlord_id", landlordId);
                    cmdTwo.Parameters.AddWithValue("@property_id", app.PropertyId);
                    cmdTwo.Parameters.AddWithValue("@name", app.Name);
                    cmdTwo.Parameters.AddWithValue("@email", app.Email);
                    cmdTwo.Parameters.AddWithValue("@tenants", app.Tenants);
                    cmdTwo.Parameters.AddWithValue("@move_in_date", app.MoveInDate);
                    cmdTwo.Parameters.AddWithValue("@income", app.Income);
                    cmdTwo.Parameters.AddWithValue("@status", app.Status);
                    appId = Convert.ToInt32(cmdTwo.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                string error = e.Message;
                throw;
            }

            return appId;
        }

        public Application GetAppFromReader(SqlDataReader reader)
        {
            Application app = new Application()
            {
                ApplicationId = Convert.ToInt32(reader["application_id"]),
                RenterId = Convert.ToInt32(reader["renter_id"]),
                LandlordId = Convert.ToInt32(reader["landlord_id"]),
                PropertyId = Convert.ToInt32(reader["property_id"]),
                Name = Convert.ToString(reader["name"]),
                Email = Convert.ToString(reader["email"]),
                Tenants = Convert.ToInt32(reader["tenants"]),
                MoveInDate = Convert.ToDateTime(reader["move_in_date"]).ToString("yyyy-MM-dd"),
                Income = Convert.ToDecimal(reader["income"]),
                Status = Convert.ToString(reader["status"]),
            };

            return app;
        }
    }
}
