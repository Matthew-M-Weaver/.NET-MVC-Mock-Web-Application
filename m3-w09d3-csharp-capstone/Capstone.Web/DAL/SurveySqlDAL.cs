using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = ParkWeather; Integrated Security = True";
        private string SQL_CommitSurvey = @"INSERT INTO survey_result values (@parkCode, @emailAddress, @state, @activityLevel);";

        public bool CommitSurvey(SurveyModel survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand(SQL_CommitSurvey, conn);
                    sqlCommand.Parameters.AddWithValue(@"parkCode", survey.ParkCode);
                    sqlCommand.Parameters.AddWithValue(@"emailAddress", survey.EmailAddress);
                    sqlCommand.Parameters.AddWithValue(@"state", survey.State);
                    sqlCommand.Parameters.AddWithValue(@"activityLevel", survey.ActivityLevel);
                    int rowsEffected = sqlCommand.ExecuteNonQuery();
                    if (rowsEffected == 1)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }
    }
}