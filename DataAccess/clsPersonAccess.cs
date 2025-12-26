using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsDataAccess
    {
        public static DataTable getAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query =
                @"select personID,NationalNO,FirstName,SecondName,ThirdName,LastName,dateOFBirth,Gendor=
                case 
                when Gendor =0 then 'Male'
                when Gendor=1 then 'Female'
                end
                ,Address,Phone,Email,countries.CountryName as Naionality,ImagePath 
                from People P
                join countries on P.NationalityCountryID = Countries.CountryID";

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
            catch (Exception ex)
            {
            }
            finally
            {
                
                connection.Close();
            }
            return dt;
        }

        public static DataTable getPeopleFilteredBy(string columnName, string value)
        {
            string[] numericColumns = { "PersonID", "Phone" };

            DataTable dt = new DataTable();
            //if the filtering text is empty return all people
            if (value == "")
                return getAllPeople();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query;

            if (numericColumns.Contains(columnName))
            {
                int.Parse(value);
                query = $@"select personID,NationalNO,FirstName,SecondName,ThirdName,LastName,dateOFBirth,Gendor=
                case 
                when Gendor =0 then 'Male'
                when Gendor=1 then 'Female'
                end
                ,Address,Phone,Email,countries.CountryName as Naionality,ImagePath 
                from People P
                join countries on P.NationalityCountryID = Countries.CountryID
                where {columnName} = @value";
            }
            else
            {
                query = $@"select personID,NationalNO,FirstName,SecondName,ThirdName,LastName,dateOFBirth,Gendor=
                case 
                when Gendor =0 then 'Male'
                when Gendor=1 then 'Female'
                end
                ,Address,Phone,Email,countries.CountryName as Naionality,ImagePath 
                from People P
                join countries on P.NationalityCountryID = Countries.CountryID
                where {columnName} like ''+ @value +'%' ";

            }
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@value", value);

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
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
    }
}
