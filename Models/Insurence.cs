using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hospital.Models
{
    public class Insurence
    {
        public int InsurenceId { get; set; }

        public string Name { get; set; }

        public string AmountSupport { get; set; }

        public int PatientId { get; set; }

        public List<Insurence> GetInsurence(string connectionString)
        {
            var insurence = new List<Insurence>();

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlQuery = "select IsurenceId, Name, AmountSupport, PatientId from Insurence";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    Insurence i = new Insurence();
                    i.InsurenceId = int.Parse(sqlDataReader["InsurenceId"].ToString());
                    i.Name = (sqlDataReader["Name"]).ToString();
                    i.AmountSupport = (sqlDataReader["AmountSupport"]).ToString();
                    i.PatientId = int.Parse(sqlDataReader["PatientId"].ToString());

                    insurence.Add(i);
                }
            }
            return insurence;
        }

        public void CreateInsurence(string conncetionString, Insurence insurence)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(conncetionString);
                SqlCommand sqlCommand = new SqlCommand("CreateInsurence", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Name", insurence.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@AmountSupport", insurence.AmountSupport));
                sqlCommand.Parameters.Add(new SqlParameter("@PatientId", PatientId));

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //we should log the exception
            }
        }

        public void DeleteInsurence(string conncetionString, int InsurenceId)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(conncetionString);
                SqlCommand sqlCommand = new SqlCommand("DeleteInsurence", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@InsurenceId", InsurenceId));

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //we should log the exception
            }
        }


    }
}
