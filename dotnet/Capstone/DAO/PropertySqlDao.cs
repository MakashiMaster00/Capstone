﻿using System;
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

        public Property GetProperty(int id)
        {
            Property property = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT property_id, landlord_id, description, address_line_one, " +
                        "address_line_two, city, state_abbreviation, zip_code, price, date_available, " +
                        "available, beds, baths FROM properties " +
                        "WHERE property_id = @property_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@property_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        property = GetPropertyFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return property;
        }

        public int AddProperty(Property property)
        {
            int propertyId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO properties (landlord_id, description, address_line_one, " +
                        "address_line_two, city, state_abbreviation, zip_code, price, date_available, " +
                        "available, beds, baths) OUTPUT INSERTED.property_id VALUES (@landlord_id, " +
                        "@description, @address_line_one, @address_line_two, @city, @state_abbreviation, " +
                        "@zip_code, @price, @date_available, @available, @beds, @baths);";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@landlord_id", property.LandlordId);
                    cmd.Parameters.AddWithValue("@description", property.Description);
                    cmd.Parameters.AddWithValue("@address_line_one", property.AddressLineOne);
                    // TODO: Need to handle a null line two
                    cmd.Parameters.AddWithValue("@address_line_two", property.AddressLineTwo);
                    cmd.Parameters.AddWithValue("@city", property.City);
                    cmd.Parameters.AddWithValue("@state_abbreviation", property.State);
                    cmd.Parameters.AddWithValue("@zip_code", property.ZipCode);
                    cmd.Parameters.AddWithValue("@price", property.Price);
                    cmd.Parameters.AddWithValue("@date_available", property.DateAvailable);
                    cmd.Parameters.AddWithValue("@available", property.Available);
                    cmd.Parameters.AddWithValue("@beds", property.Beds);
                    cmd.Parameters.AddWithValue("@baths", property.Baths);

                    propertyId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return propertyId;
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