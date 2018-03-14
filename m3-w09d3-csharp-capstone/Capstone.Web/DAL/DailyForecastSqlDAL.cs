using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class DailyForecastSqlDAL : IDailyForecastDAL
    {
        private string connectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = ParkWeather; Integrated Security = True";
        private string SQL_GetDailyForecasts = @"SELECT * FROM weather WHERE parkCode = @parkCode;";

        public List<DailyForecast> GetDailyForecasts(ParkModel park)
        {
            try
            {
                List<DailyForecast> fiveDayForecast = new List<DailyForecast>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetDailyForecasts, connection);
                    cmd.Parameters.AddWithValue("@parkCode", park.ParkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DailyForecast forecast = new DailyForecast();
                        forecast.Day = Convert.ToInt16(reader["fiveDayForecastValue"]);
                        forecast.Low = Convert.ToInt16(reader["low"]);
                        forecast.High = Convert.ToInt16(reader["high"]);
                        forecast.Conditions = Convert.ToString(reader["forecast"]);
                        fiveDayForecast.Add(forecast);
                    }
                }
                return fiveDayForecast;
            }
            catch (SqlException ex)
            {
                throw;
            }

        }
    }
}