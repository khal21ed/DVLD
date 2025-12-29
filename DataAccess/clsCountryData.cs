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
        public static int findCountryByName(string countryName)
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
            catch (Exception ex) { }
            finally
            {
                connection.Close();   
            }
            return countryID;
        }
        public static DataTable getAllCountryNames()
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
