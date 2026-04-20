using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class clsTestTypesAccess
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from TestTypes";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }

        public static bool UpdateTestType(int testTypeID,string testTypeTitle,string testTypeDescription,
            int testTypeFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Update TestTypes
                            Set TestTypeTitle=@TestTypeTitle,
                            TestTypeDescription=@TestTypeDescription,
                            TestTypeFees=@TestTypeFees
                            where TestTypeID=@TestTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", testTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", testTypeFees);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) 
                    return true;
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return false;
        }

        public static bool FindTestTypeByID(int testTypeID,
           ref string testTypeTitle, ref string testTypeDescription, ref int testTypeFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "Select * from TestTypes where TestTypeID=@TestTypeID";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", testTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", testTypeFees);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    testTypeTitle = reader["TestTypeTitle"].ToString();
                    testTypeDescription = reader["TestTypeDescription"].ToString();
                    testTypeFees = Convert.ToInt32(reader["TestTypeFees"]);
                    reader.Close();
                    return true;
                }
                
            }
            catch (Exception ex) { } 
            finally { connection.Close(); }
            return false;
        }

        public static float GetApplicationTypeFeesByID(int testTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"  select TestTypeFees from TestTypes
                                where TestTypeID=@TestTypeID";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null&&float.TryParse(result.ToString(),out float fees))
                {
                    return fees;
                }
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return 0;
        }
    }
}
