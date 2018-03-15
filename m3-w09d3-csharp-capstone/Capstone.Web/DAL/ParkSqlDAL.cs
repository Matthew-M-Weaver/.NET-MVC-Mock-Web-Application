using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString;
        private string SQL_GetIndexInformation = @"SELECT parkCode, parkName, parkDescription FROM park;";
        private string SQL_GetDetailInformation = @"SELECT * FROM park WHERE parkCode = @code;";

        public ParkSqlDAL()
        {

        }

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetIndexInformation()
        {
            try
            {
                List<ParkModel> parks = new List<ParkModel>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetIndexInformation, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel park = new ParkModel();
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        parks.Add(park);
                    }
                }
                return parks;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public ParkModel GetDetailInformation(ParkModel park)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetDetailInformation, connection);
                    cmd.Parameters.AddWithValue(@"@Code", park.ParkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt64(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt16(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDecimal(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt16(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt16(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt64(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.EntryFee = Convert.ToInt16(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt16(reader["numberOfAnimalSpecies"]);
                        park.TempType = "F";
                        park.NeedsConverted = false;
                    }
                }
                return park;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}