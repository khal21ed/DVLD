using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsLicenseClassAccess
    {
        public static DataTable GetAllLicenseClassNames()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select LicenseClassID,ClassName from LicenseClasses";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return dt;
        }
        public static string GetLicenseClassNameByID(int licenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select ClassName from LicenseClasses 
                            where LicenseClassID=@LicenseClassID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    return result.ToString();

            }
            catch (Exception ex){ throw; }
            finally { connection.Close(); }
            return null;
        }
        public static byte GetLicenseClassValidatyLength(int licenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Select DefaultValidityLength from LicenseClasses 
                        Where LicenseClassID=@LicenseClassID";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && byte.TryParse(result.ToString(), out byte validatyLength))
                    return validatyLength;
            }
            catch (Exception ex){ throw; }
            finally { connection.Close(); }
            return 0;
        }

        public static float GetLicenseClassPaidFees(int licenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Select ClassFees from LicenseClasses
                            Where LicenseClassID =@LicenseClassID  ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if(result!=null && float.TryParse(result.ToString(),out float paidFees))
                        return paidFees;
            }
            catch (Exception ex){ throw; } 
            finally { connection.Close(); }
            return 0;
        }
    }
}
