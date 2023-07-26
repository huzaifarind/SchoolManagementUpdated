using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class StudentsDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddStudent(Students smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Students", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Insert");
            cmd.Parameters.AddWithValue("@EnrollmentNo", smodel.EnrollmentNo);
            cmd.Parameters.AddWithValue("@StudentName", smodel.StudentName);
            cmd.Parameters.AddWithValue("@StudentMobNo", smodel.StudentMobNo);
            cmd.Parameters.AddWithValue("@StudentAddress", smodel.StudentAddress);
            cmd.Parameters.AddWithValue("@StudentEmail", smodel.StudentEmail);
            cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@GuardianId", smodel.GuardianId);
            cmd.Parameters.AddWithValue("@DOB", smodel.DOB); // Make sure to set the Date of Birth

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Students> GetStudent()
        {
            connection();
            List<Students> studentlist = new List<Students>();

            SqlCommand cmd = new SqlCommand("CRUD_Students", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OperationType", "Select"); // Specify the operation type as "Select"
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new Students
                    {
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        EnrollmentNo = dr["EnrollmentNo"].ToString(),
                        StudentName = dr["StudentName"].ToString(),
                        StudentMobNo = dr["StudentMobNo"].ToString(),
                        StudentAddress = dr["StudentAddress"].ToString(),
                        StudentEmail = dr["StudentEmail"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        GuardianId = Convert.ToInt32(dr["GuardianId"]),
                        DOB = Convert.ToDateTime(dr["DOB"]) // Make sure to convert to DateTime
                    });
            }
            return studentlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(Students smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Students", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Update");
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@EnrollmentNo", smodel.EnrollmentNo);
            cmd.Parameters.AddWithValue("@StudentName", smodel.StudentName);
            cmd.Parameters.AddWithValue("@StudentMobNo", smodel.StudentMobNo);
            cmd.Parameters.AddWithValue("@StudentAddress", smodel.StudentAddress);
            cmd.Parameters.AddWithValue("@StudentEmail", smodel.StudentEmail);
            cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@GuardianId", smodel.GuardianId);
            cmd.Parameters.AddWithValue("@DOB", smodel.DOB); // Make sure to set the Date of Birth

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE STUDENT DETAILS **********************
        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Students", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Delete");
            cmd.Parameters.AddWithValue("@StudentId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
