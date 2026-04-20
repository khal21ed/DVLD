using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsInternationalLicenseAccess
    {
  
        public static DataTable GetAllInternationalLicensesPerPerson(int personID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select InternationalLicenseID ,A.ApplicationID,IL.IssuedUsingLocalLicenseID,
                IL.IssueDate,IL.ExpirationDate,IL.IsActive 
                from InternationalLicenses  IL
                join Applications A on A.ApplicationID=IL.ApplicationID
                where A.ApplicantPersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", personID);

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

        public static int HasInternationalLicenseByLDLID(int LDLID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select InternationalLicenseID from InternationalLicenses
                where IssuedUsingLocalLicenseID=@LDLID";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@LDLID", LDLID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null&&int.TryParse(result.ToString(),out int intLicenseID))
                    return intLicenseID;

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }
        public static DataTable GetInternationalLicenseCardInfo(int intLicenseID)
        {
            DataTable dt= new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT 
       IL.InternationalLicenseID AS IntLicenseID,
    IL.ApplicationID,
    IL.IssuedUsingLocalLicenseID,
    IL.IsActive,
    P.NationalNo,
     firstName+' '+SecondName+
                        case 
                        when ThirdName is not null then ' '+ThirdName+' ' 
                        else ' ' 
                        end +LastName as FullName,
    P.DateOfBirth,
    P.Gendor,
     IL.DriverID,
    IL.IssueDate,
    IL.ExpirationDate,
    P.ImagePath
FROM InternationalLicenses IL
JOIN Drivers D ON D.DriverID = IL.DriverID
JOIN People P ON P.PersonID = D.PersonID
WHERE IL.InternationalLicenseID = @IntLicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@IntLicenseID", intLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return dt;
        }
        public static int AddInternationalLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID,
                      DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {

            SqlConnection connection =
                   new SqlConnection(clsDataAccessSettings.connectionString);


                string query = @"INSERT INTO InternationalLicenses
                         (ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                          IssueDate,ExpirationDate, IsActive, CreatedByUserID)
                         VALUES
                         (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,
                          @IssueDate,@ExpirationDate, @IsActive, @CreatedByUserID);
                         SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int intLicenseID))
                    return intLicenseID;
            }
                
            
            catch(Exception ex){ throw; }
            finally { connection.Close(); }
            return -1;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt= new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select InternationalLicenseID as IntLicenseID,ApplicationID,
            driverID,IssuedUsingLocalLicenseID as LLicenseID,IssueDate,ExpirationDate,IsActive
            from InternationalLicenses";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch(Exception ex){ throw; }
            finally { connection.Close(); }
            return dt;
        }
    }
}
