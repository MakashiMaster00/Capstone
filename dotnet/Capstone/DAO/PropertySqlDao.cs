using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class PropertySqlDao : IPropertyDao
    {
        private readonly string connectionString;
        public PropertySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Property> GetProperties()
        {
            List<Property> properties = new List<Property>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT property_id, landlord_id, description, address_line_one, " +
                        "address_line_two, city, state_abbreviation, zip_code, price, date_available, " +
                        "available, beds, baths FROM properties";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        properties.Add(GetPropertyFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return properties;
        }

        public Property GetPropertyFromReader(SqlDataReader reader)
        {
            Property p = new Property()
            {
                PropertyId = Convert.ToInt32(reader["property_id"]),
                LandlordId = Convert.ToInt32(reader["landlord_id"]),
                Description = Convert.ToString(reader["description"]),
                AddressLineOne = Convert.ToString(reader["address_line_one"]),
                AddressLineTwo = Convert.ToString(reader["address_line_two"]),
                City = Convert.ToString(reader["city"]),
                State = Convert.ToString(reader["state_abbreviation"]),
                ZipCode = Convert.ToString(reader["zip_code"]),
                Price = Convert.ToDecimal(reader["price"]),
                DateAvailable = Convert.ToDateTime(reader["date_available"]).ToString("d"),
                Available = Convert.ToBoolean(reader["available"]),
                Beds = Convert.ToInt32(reader["beds"]),
                Baths = Convert.ToDouble(reader["baths"])
            };

            return p;
        }
    }
}
