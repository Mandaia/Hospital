using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Section { get; set; }

        public List<Patient> GetPatient(string connectionString)
        {
            var patients = new List<Patient>();

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlQuery = "select Id, Name, Age, Section from Patient";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    Patient patient = new Patient();
                    patient.Id = int.Parse(sqlDataReader["Id"].ToString());
                    patient.Name = sqlDataReader["Name"].ToString();
                    patient.Age = int.Parse(sqlDataReader["Age"].ToString());
                    patient.Section = (sqlDataReader["Section"]).ToString();

                    patients.Add(patient);
                }
            }

            return patients;

        }

        public void CreatePatient(string conncetionString, Patient patient)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(conncetionString);
                SqlCommand sqlCommand = new SqlCommand("CreatePatient", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Name", patient.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@Age", patient.Age));
                sqlCommand.Parameters.Add(new SqlParameter("@Section", patient.Section));

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //we should log the exception
            }
        }

        public void DeletePatient(string conncetionString, int PatientId)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(conncetionString);
                SqlCommand sqlCommand = new SqlCommand("DeletePatient", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Id", PatientId));

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
