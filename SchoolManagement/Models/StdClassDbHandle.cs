using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class StdClassDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddStdClass(StdClass smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStdClass", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@ClassId", smodel.ClassId);
            cmd.Parameters.AddWithValue("@Class", smodel.Class);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@SectionId", smodel.SectionId);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<StdClass> GetStdAttendence()
        {
            connection();
            List<StdClass> StdClasslist = new List<StdClass>();

            SqlCommand cmd = new SqlCommand("GetStdClassDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                StdClasslist.Add(
                    new StdClass
                    {
                        ClassId = Convert.ToInt32(dr["ClassId"]),
                        Class = Convert.ToString(dr["Class"]),
                        StudentId = Convert.ToString(dr["StudentId"]),
                        SectionId = Convert.ToString(dr["SectionId"]),

                    });
            }
            return StdClasslist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(StdClass smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStdClassDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@AttendenceId", smodel.ClassId);
            cmd.Parameters.AddWithValue("@Attendence", smodel.Class);
            cmd.Parameters.AddWithValue("@ClassId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@StudentId", smodel.SectionId);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteStdClass(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStdClass", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your model class
            cmd.Parameters.AddWithValue("@ClassId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
