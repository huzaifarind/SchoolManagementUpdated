using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class CourseDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddCourse(Course smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@CourseId", smodel.CourseId);
            cmd.Parameters.AddWithValue("@CourseName", smodel.CourseName);
            cmd.Parameters.AddWithValue("@TeacherId", smodel.TeacherId);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Course> GetCourse()
        {
            connection();
            List<Course> Courselist = new List<Course>();

            SqlCommand cmd = new SqlCommand("GetCourseDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Courselist.Add(
                    new Course
                    {
                        CourseId = Convert.ToInt32(dr["CourseId"]),
                        CourseName = Convert.ToString(dr["CourseName"]),
                        TeacherId = Convert.ToInt32(dr["TeacherId"]),
                        StudentId = Convert.ToInt32(dr["StudentId"]),

                    });
            }
            return Courselist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(Course smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateCourseDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@CourseId", smodel.CourseId);
            cmd.Parameters.AddWithValue("@CourseName", smodel.CourseName);
            cmd.Parameters.AddWithValue("@TeacherId", smodel.TeacherId);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteCourse(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your model class
            cmd.Parameters.AddWithValue("@CourseId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
