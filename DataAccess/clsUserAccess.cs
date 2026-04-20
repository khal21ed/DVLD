using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsUserAccess
    {
        public static bool GetUserByUsernameAndPassword(string username, string password, ref int userID,
            ref int personID, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from users
                  where UserName COLLATE Latin1_General_CS_AS =@UserName
                  and Password=@Password";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userID = int.Parse(reader["UserID"].ToString());
                    personID = int.Parse(reader["PersonID"].ToString());
                    isActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    reader.Close();
                    return true;
                }
                reader.Close();
            }
            catch (Exception ex) { throw; }

            finally { connection.Close(); }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from(
                        select  UserId,P.PersonID,
                        firstName+' '+SecondName+
                        case when ThirdName is not null then ' '+ThirdName 
                        else ' ' 
                        end+LastName as FullName,UserName,IsActive
                        from Users U
                        join People P on P.PersonID=U.PersonID
                        )R ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { throw; }

            finally { connection.Close(); }

            return dt;
        }

        public static bool UserExistsByPersonId(int personID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select found=1 from Users where PersonID=@PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    return true;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }
        public static bool UserExistsByUserName(string username)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select found=1 from Users where UserName=@UserName";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", username);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    return true;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }

        public static int AddUser(int personID, string username, string password, bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into Users(PersonID,username,Password,IsActive)
                        values(@PersonID,@UserName,@Password,@IsActive)
                        select Scope_Identity()";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    return ID;
                }

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }

        public static bool UpdateUser(int userID, int personID, string username, string password, bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Update users 
                            set PersonID=@PersonID,
                            UserName=@UserName,
                            Password=@Password,
                            IsActive=@IsActive
                            where UserId=@UserID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return true;
                }
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }
        public static bool FindUserByUserID(int userID, ref int personID, ref string username,
            ref string password, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from Users where UserID=@UserID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("UserID", userID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    personID = int.Parse((reader["PersonID"].ToString()));
                    username = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    return true;
                }

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }

        public static void DeleteUser(int userID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "Delete from Users where UserID=@UserID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }

        }

        public static bool ChangePassword(int userID, string password)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Update Users
                            Set Password=@Password
                            where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }

        public static string GetUserNameByUserID(int userID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select UserName from Users where UserID=@UserID";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    return result.ToString();
            }
            catch (Exception ex) { throw; } 
            finally { connection.Close(); }
            return null;
        }
    }
}
