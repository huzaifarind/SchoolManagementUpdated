using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class StdAttendenceDbHandle
    {
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW ATTENDANCE *********************
        public bool AddAttendence(StdAttendence smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Attendence", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Insert");
            cmd.Parameters.AddWithValue("@Attendence", smodel.Attendence);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@ClassId", smodel.ClassId);
            cmd.Parameters.AddWithValue("@Date", smodel.Date);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW ATTENDANCE DETAILS ********************
        public List<StdAttendence> GetAttendence()
        {
            connection();
            List<StdAttendence> stdAttendences = new List<StdAttendence>();

            SqlCommand cmd = new SqlCommand("CRUD_Attendence", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OperationType", "Select"); // Specify the operation type as "Select"
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                stdAttendences.Add(
                    new StdAttendence
                    {
                        AttendenceId = Convert.ToInt32(dr["AttendenceId"]),
                        Attendence = dr["Attendence"].ToString(),
                        ClassId = Convert.ToInt32(dr["Class"]),
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        StudentName = dr["StudentName"].ToString(),
                        Date = Convert.ToDateTime(dr["Date"]) // Make sure to convert to DateTime
                    });
            }
            return stdAttendences;
        }

        // ***************** UPDATE ATTENDANCE DETAILS *********************
        public bool UpdateAttendence(StdAttendence smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Attendence", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Update");
            cmd.Parameters.AddWithValue("@AttendenceId", smodel.AttendenceId);
            cmd.Parameters.AddWithValue("@Attendence", smodel.Attendence);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@ClassId", smodel.ClassId);
            cmd.Parameters.AddWithValue("@Date", smodel.Date);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE ATTENDANCE DETAILS **********************
        public bool DeleteAttendence(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Attendence", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Delete");
            cmd.Parameters.AddWithValue("@AttendenceId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
