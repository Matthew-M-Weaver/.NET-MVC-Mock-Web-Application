using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveyResultSqlDAL : ISurveyResultDAL
    {
        private string connectionString;
        private string SQL_GetSurveyResults = @"SELECT COUNT(survey_result.parkCode) as votes, park.parkName FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode GROUP BY park.parkName ORDER BY votes DESC;";

        public SurveyResultSqlDAL()
        {

        }

        public SurveyResultSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SurveyResult> GetSurveyResults()
        {
            try
            {
                List<SurveyResult> rankings = new List<SurveyResult>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetSurveyResults, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult park = new SurveyResult();
                        park.ParkName = Convert.ToString(reader["park.parkName"]);
                        park.Count = Convert.ToInt16(reader["votes"]);
                        rankings.Add(park);
                    }
                }
                return rankings;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}