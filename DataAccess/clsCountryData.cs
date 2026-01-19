using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsCountryData
    {
        public static int FindCountryByName(string countryName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            int countryID = -1;
            string query = @"select CountryID From countries
                            where CountryName = @countryName";
            SqlCommand cmd  = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@countryName", countryName);

            try
            {
                connection.Open();
                object result=cmd.ExecuteScalar();

                if(result != null)
                {
                    int.TryParse(result.ToString(), out countryID);                   
                }
                
            }
            catch (Exception ex) { throw; }
            finally
            {
                connection.Close();   
            }
            return countryID;
        }

        public static string FindCountryByCountryID(int countryID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select CountryName from Countries
                            where CountryID=@CountryID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryID", countryID);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }
            }

            catch (Exception ex) { throw; }

            finally { connection.Close(); }
            return null;
        }
        public static DataTable GetAllCountryNames()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            DataTable dt = new DataTable();

            string query = "select CountryName from Countries order by CountryName asc";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
