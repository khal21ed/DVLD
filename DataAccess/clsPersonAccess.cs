using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsPersonData
    {
        public static DataTable GetAllPeople()
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
        public static DataTable GetPeopleFilteredBy(string columnName, string value)
        {
            string[] numericColumns = { "PersonID", "Phone" };

            DataTable dt = new DataTable();
            //if the filtering text is empty return all people
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(columnName))
                return GetAllPeople();
            if (columnName.ToLower()=="gendor")
            {
                if (value.ToLower() == "male")
                    value = "0";
                else if (value.ToLower() == "female")
                    value = "1";
                else
                    return dt;
                }

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

        public static int AddNewPerson(string nationalNumber, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth
            , string address, string phone, int gendor, string email, int country, string imagepath)
        {
            int personID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into people (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                            values(@NationalNumber,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,
                                    @Gendor,@Address,@Phone,@Email,@Country,@ImagePath)
                                    select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@NationalNumber", nationalNumber);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@SecondName", secondName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@ThirdName", thirdName);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Gendor", gendor);
            if(string.IsNullOrEmpty(email))
                cmd.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Email", email);
                
            cmd.Parameters.AddWithValue("@Country", country);
            if(string.IsNullOrEmpty( imagepath))
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ImagePath", imagepath);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if(result!= null && int.TryParse(result.ToString(),out personID))
                {
                    return personID;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { connection.Close(); }

            return personID;

        }

        public static bool PersonExistsByNationalNo(string nationalID)
        {
            if(string.IsNullOrEmpty(nationalID))
                return false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select found=1 from People where NationalNo = @nationalNo";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nationalNo",nationalID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return true;
                }
            }
            catch (Exception ex) { }

            finally { connection.Close(); }

            return false;
        }
    }
}
