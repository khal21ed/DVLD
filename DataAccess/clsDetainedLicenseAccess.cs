using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsDetainedLicenseAccess
    {
        public static bool FindDetainedLicense(int licenseID,ref int detainedID ,ref DateTime detainDate,
            ref float fineFee,ref int createdByUserID,ref bool isReleased,ref DateTime releaseTime,
            ref int releasedByUserID,ref int releaseAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select top 1 * from DetainedLicenses where LicenseID=@LicenseID
order by DetainID desc";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    detainedID = Convert.ToInt32(reader["DetainID"]);
                    detainDate = Convert.ToDateTime(reader["DetainDate"]);
                    fineFee = Convert.ToSingle(reader["FineFees"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isReleased = Convert.ToBoolean(reader["IsReleased"]);

                    releaseTime = reader["ReleaseDate"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(reader["ReleaseDate"]);

                    releasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                        ? -1
                        : Convert.ToInt32(reader["ReleasedByUserID"]);

                    releaseAppID = reader["ReleaseApplicationID"] == DBNull.Value
                        ? -1
                        : Convert.ToInt32(reader["ReleaseApplicationID"]);
                    return true;
                }

            }
            catch (Exception ex) { throw; }
            finally {  connection.Close(); }
            return false;
        }

        public static int AddNewDetainedLicense(int licenseID, DateTime detainDate,float fineFee,  int createdByUserID)
      //We Are not gonna detain a license and release it at the same time so there is no need to pass value for the release columns here

        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"INSERT INTO DetainedLicenses
                        (LicenseID, DetainDate, FineFees, CreatedByUserID,
                         IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                         VALUES
                        (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID,
                         0, Null, NULL, NULL);

                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", licenseID);
                    cmd.Parameters.AddWithValue("@DetainDate", detainDate);
                    cmd.Parameters.AddWithValue("@FineFees", fineFee);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    //cmd.Parameters.AddWithValue("@IsReleased", isReleased);

                    //if (releaseTime == DateTime.MinValue)
                    //cmd.Parameters.AddWithValue("@ReleaseTime",DBNull.Value );
                    //else
                    //    cmd.Parameters.AddWithValue("@ReleaseTime",releaseAppID);

                    //if(releasedByUserID == -1)
                    //cmd.Parameters.AddWithValue("@ReleasedByUserID",DBNull.Value);
                    //else
                    //    cmd.Parameters.AddWithValue("@ReleasedByUserID",releasedByUserID);

                    //if (releaseAppID == -1)
                    //    cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                    //else
                    //    cmd.Parameters.AddWithValue("@ReleaseApplicationID", releasedByUserID);


                    try
                    {
                            connection.Open();
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                                return Convert.ToInt32(result);
                        }
                        catch{ throw;}
                    finally { connection.Close(); }
                }
            }

            return -1;
        }

        public static bool ReleaseDetainedLicense(int detainID,DateTime releaseDate,int releasedByUserID,int releasedAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Update DetainedLicenses
set IsReleased=1,
ReleaseDate=@ReleaseDate,
ReleasedByUserID=@ReleasedByUserID,
ReleaseApplicationID=@ReleaseApplicationID
where DetainID=@DetainID";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            cmd.Parameters.AddWithValue("@DetainID", detainID);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", releasedAppID);

            try
            {
                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows != 0)
                    return true;
            }
            catch { throw;}
            finally { connection.Close(); }
            return false;
        }

        public static DataTable GetDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from DetainedLicenses_View";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                reader.Close();
            }
            catch { throw;}
            finally { connection.Close(); } 
            return dt;
        }
    }
}
