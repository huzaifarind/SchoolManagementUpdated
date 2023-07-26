using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class FeeDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddFee(Fee smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewFee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@FeeId", smodel.FeeId);
            cmd.Parameters.AddWithValue("@TotalFee", smodel.TotalFee);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@Date", smodel.Date);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Fee> GetFee()
        {
            connection();
            List<Fee> Feelist = new List<Fee>();

            SqlCommand cmd = new SqlCommand("GetFeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Feelist.Add(
                    new Fee
                    {
                        FeeId = Convert.ToInt32(dr["ClassId"]),
                        TotalFee = Convert.ToDecimal(dr["Class"]),
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        Date = Convert.ToDateTime(dr["SectionId"]),

                    });
            }
            return Feelist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(Fee smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateFeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@FeeId", smodel.FeeId);
            cmd.Parameters.AddWithValue("@TotalFee", smodel.TotalFee);
            cmd.Parameters.AddWithValue("@StudentId", smodel.StudentId);
            cmd.Parameters.AddWithValue("@Date", smodel.Date);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteFee(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteFeeClass", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your model class
            cmd.Parameters.AddWithValue("@FeeId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
