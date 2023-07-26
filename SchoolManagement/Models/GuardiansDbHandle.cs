using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement.Models
{
    public class GuardiansDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddGuardian(Guardians smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Guardian", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Insert");
            cmd.Parameters.AddWithValue("@GuardianId", smodel.GuardianId);
            cmd.Parameters.AddWithValue("@GuardianName", smodel.GuardianName);
            cmd.Parameters.AddWithValue("@GuardianMobNo", smodel.GuardianMobNo);
            cmd.Parameters.AddWithValue("@GuardianEmail", smodel.GuardianEmail);
           // Make sure to set the Date of Birth

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Guardians> GetGuardians()
        {
            connection();
            List<Guardians> guardianslist = new List<Guardians>();

            SqlCommand cmd = new SqlCommand("CRUD_Guardian", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OperationType", "Select"); // Specify the operation type as "Select"
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                guardianslist.Add(
                    new Guardians
                    {
                        GuardianId = Convert.ToInt32(dr["GuardianId"]),
                        GuardianName = dr["GuardianName"].ToString(),
                        GuardianMobNo = dr["GuardianMobNo"].ToString(),
                        GuardianEmail = dr["GuardianEmail"].ToString()
                     
                    });
            }
            return guardianslist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(Guardians smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Guardian", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameters as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Update");
            cmd.Parameters.AddWithValue("@GuardianId", smodel.GuardianId);
            cmd.Parameters.AddWithValue("@GuardianName", smodel.GuardianName);
            cmd.Parameters.AddWithValue("@GuardianMobNo", smodel.GuardianMobNo);
            cmd.Parameters.AddWithValue("@GuardianEmail", smodel.GuardianEmail);
        
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }

        // ********************** DELETE STUDENT DETAILS **********************
        public bool DeleteGuardian(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("CRUD_Guardian", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Use the same parameter name as your stored procedure
            cmd.Parameters.AddWithValue("@OperationType", "Delete");
            cmd.Parameters.AddWithValue("@GuardianId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1; // Simplify the return statement
        }
    }
}
