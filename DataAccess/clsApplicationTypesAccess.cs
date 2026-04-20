using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class clsApplicationTypesAccess
    {
        public static DataTable GetAllApplicatoinTypes()
        {
            DataTable dt=new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from ApplicationTypes";

            SqlCommand cmd = new SqlCommand(query,connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

            }
            catch (Exception ex) { throw;}
            finally { connection.Close(); }
            return dt;
        }

        public static bool FindApplicationType(int applicationId, ref string title,ref float fees)
        {
            SqlConnection connection =new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationId);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    title = reader["ApplicationTypeTitle"].ToString();
                    fees = float.Parse((reader["ApplicationFees"].ToString()));
                    reader.Close();
                    return true;
                }
            }
            catch(Exception ex) { throw; } 
            finally { connection.Close(); }
            return false;
        }

        public static bool UpdateApplicatoinType(int applicationID,string title,float fees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Update ApplicationTypes
                            set ApplicationTypeTitle=@ApplicationTypeTitle,
                                ApplicationFees=@ApplicationFees
                            where ApplicationTypeID=@ApplicationTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", title);
            cmd.Parameters.AddWithValue("@ApplicationFees", fees);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) 
                {
                    return true;
                }
            }
            catch(Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }

        public static float GetApplicationTypeFee(int applicationTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select ApplicationFees from ApplicationTypes
                        where ApplicationTypeID =@ApplicationTypeID ";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if(result!=null && float.TryParse(result.ToString(),out float fee))
                        return fee;

            }
            catch(Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        } 
    }
}
