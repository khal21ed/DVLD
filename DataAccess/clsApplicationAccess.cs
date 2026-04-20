using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsApplicationAccess
    {
        public static int AddNewApplicatoin(int appPersonID,DateTime appDate,int appTypeID,byte appStatus,
            DateTime lastStatusDate,float paidFees,int createdByUser)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"INSERT INTO Applications
                        (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                        VALUES
                        (@ApplicantPersonID, @ApplicationDate,@ApplicationTypeID,@ApplicationStatus,
                        @LastStatusDate,@PaidFees, @CreatedByUserID)

                        SELECT SCOPE_IDENTITY() AS ApplicationID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", appPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", appDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", appTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", appStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUser);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int applicatoinID))
                    return applicatoinID;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }

        public static bool FindApplicationByID(int appID, ref int appPersonID, ref DateTime appDate, ref int appTypeID, ref byte appStatus,
           ref DateTime lastStatusDate, ref float paidFees, ref int createdByUser)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from Applications where ApplicationID=@ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", appID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    appPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                    appDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    appTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    appStatus = Convert.ToByte(reader["ApplicationStatus"]);
                    lastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUser = Convert.ToInt32(reader["CreatedByUserID"]);
                    reader.Close();
                    return true;
                }
                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
            
        }
    }
}
