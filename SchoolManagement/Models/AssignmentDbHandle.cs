using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class AssignmentDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddAssignment(Assignment smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewAssignment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@AssignmentId", smodel.AssignmentId);
            cmd.Parameters.AddWithValue("@AssignmentName", smodel.AssignmentName);
            cmd.Parameters.AddWithValue("@AssignmentType", smodel.AssignmentType);
            cmd.Parameters.AddWithValue("@SubmissionDate", smodel.SubmissionDate);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Assignment> GetAssigment()
        {
            connection();
            List<Assignment> Assignmentlist = new List<Assignment>();

            SqlCommand cmd = new SqlCommand("GetAssignmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Assignmentlist.Add(
                    new Assignment
                    {
                        AssignmentId = Convert.ToInt32(dr["AssignmentId"]),
                        AssignmentName = Convert.ToString(dr["AssignmentName"]),
                        AssignmentType = Convert.ToString(dr["AssignmentType"]),
                        SubmissionDate = Convert.ToDateTime(dr["SubmissionDate"]),

                    });
            }
            return Assignmentlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(Assignment smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateAssignmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your model class
            cmd.Parameters.AddWithValue("@AssignmentId", smodel.AssignmentId);
            cmd.Parameters.AddWithValue("@AssignmentName", smodel.AssignmentName);
            cmd.Parameters.AddWithValue("@AssignmentType", smodel.AssignmentType);
            cmd.Parameters.AddWithValue("@SubmissionDate", smodel.SubmissionDate);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteAssignment(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteAssignment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your model class
            cmd.Parameters.AddWithValue("@AssignmentId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
