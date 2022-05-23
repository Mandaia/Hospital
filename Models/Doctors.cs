using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hospital.Models
{
    public class Doctors
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Section { get; set; }

        public int HWeek { get; set; }

        public int HireDate { get; set; }

        public List<Doctors> GetDoctors(string connectionString)
        {
            var doctors = new List<Doctors>();

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlQuery = "select Id, Name , Section, H/Week, HireDate from Doctors";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    Doctors doctor = new Doctors();
                    doctor.Id = int.Parse(sqlDataReader["Id"].ToString());
                    doctor.Name = (sqlDataReader["Name"]).ToString();
                    doctor.Section = (sqlDataReader["Section"]).ToString();
                    doctor.HWeek = int.Parse(sqlDataReader["H/Week"].ToString());
                    doctor.HireDate = int.Parse(sqlDataReader["HireDate"].ToString());


                    doctors.Add(doctor);
                }
            }

            return doctors;

        }

        public Doctors GetDoctorData(string connectionString, int userId)
        {
            var doctors = new Doctors();

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlQuery = "select Id, Name , Section, H/Week, HireDate from Doctors";

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    Doctors doctor = new Doctors();
                    doctor.Id = int.Parse(sqlDataReader["Id"].ToString());
                    doctor.Name = (sqlDataReader["Name"]).ToString();
                    doctor.Section = (sqlDataReader["Section"]).ToString();
                    doctor.HWeek = int.Parse(sqlDataReader["H/Week"].ToString());
                    doctor.HireDate = int.Parse(sqlDataReader["HireDate"].ToString());
                }
            }

            return doctors;

        }

        public void CreateDoctor(string conncetionString, Doctors doctor)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(conncetionString);
                SqlCommand sqlCommand = new SqlCommand("CreateDoctor", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Name", doctor.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@Section", doctor.Section));
                sqlCommand.Parameters.Add(new SqlParameter("@HWeek", doctor.HWeek));
                sqlCommand.Parameters.Add(new SqlParameter("@HireDate", doctor.HireDate));

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //we should log the exception
            }
        }

        public void DeleteDoctor(string conncetionString, int DoctorId)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(conncetionString);
                SqlCommand sqlCommand = new SqlCommand("DeleteDoctor", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Id", DoctorId));

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
