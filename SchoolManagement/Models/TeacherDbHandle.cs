using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class TeacherDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW TEACHER *********************
        public bool AddTeachers(Teachers smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewTeacher", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@TeacherId", smodel.TeacherId);
            cmd.Parameters.AddWithValue("@TeacherName", smodel.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherMobile", smodel.TeacherMobileNo);
            cmd.Parameters.AddWithValue("@TeacherAddress", smodel.TeacherAddress);
            cmd.Parameters.AddWithValue("@TeacherEmail", smodel.TeacherEmail);
            cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@GuardianId", smodel.Qualification);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Teachers> GetTeacher()
        {
            connection();
            List<Teachers> Teacherlist = new List<Teachers>();

            SqlCommand cmd = new SqlCommand("GetTeacherDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Teacherlist.Add(
                    new Teachers
                    {
                        TeacherId = Convert.ToInt32(dr["TeacherId"]),
                        TeacherName = Convert.ToString(dr["TeacherName"]),
                        TeacherMobileNo = Convert.ToString(dr["TeacherMobileNo"]),
                        TeacherAddress = Convert.ToString(dr["TeacherAddress"]),
                        TeacherEmail = Convert.ToString(dr["TeacherEmail"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Qualification = Convert.ToString(dr["Qualification"])
                    });
            }
            return Teacherlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(Teachers smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateTeachersDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@TeacherId", smodel.TeacherId);
            cmd.Parameters.AddWithValue("@TeacherName", smodel.TeacherName);
            cmd.Parameters.AddWithValue("@TeacherMobile", smodel.TeacherMobileNo);
            cmd.Parameters.AddWithValue("@TeacherAddress", smodel.TeacherAddress);
            cmd.Parameters.AddWithValue("@TeacherEmail", smodel.TeacherEmail);
            cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@GuardianId", smodel.Qualification);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE TEACHERS DETAILS *******************
        public bool DeleteTeachers(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteTeachers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your model class
            cmd.Parameters.AddWithValue("@TeacherId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
