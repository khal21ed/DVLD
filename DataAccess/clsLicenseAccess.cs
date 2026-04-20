using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsLicenseAccess
    {
        public static int AddNewDrivingLicense(int appID,int driverID,int licenseClass,DateTime issueDate,
            DateTime expirationDate,string notes,float paidFees,bool isActive,byte issueReason,int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"
INSERT INTO Licenses
(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
 Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
VALUES
(@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
 @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
 select SCOPE_IDENTITY();
";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", appID);
            cmd.Parameters.AddWithValue("@DriverID", driverID);
            cmd.Parameters.AddWithValue("@LicenseClass", licenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            if(string.IsNullOrWhiteSpace(notes))
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Notes", notes);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@IsActive", isActive);
            cmd.Parameters.AddWithValue("@IssueReason", issueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int licenseID))
                {
                    return licenseID;
                }
            }
            catch (Exception ex) { throw; }
            finally {  connection.Close(); }
            return -1;
        }

        public static bool HasLicenseForApplicatoin(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select found = 1 from LocalDrivingLicenseApplications LD
            join Applications A on LD.ApplicationID=A.ApplicationID
            join Licenses L on L.ApplicationID=A.ApplicationID
            where LD.LocalDrivingLicenseApplicationID =@LDLAppID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

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

        public static DataTable GetLicenseInfo(int licenseID)
        {
            DataTable dtInfo=new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select LC.ClassName, firstName+' '+SecondName+
                        case 
                        when ThirdName is not null then ' '+ThirdName+' ' 
                        else ' ' 
                        end +LastName as FullName,L.LicenseID,P.NationalNo,
                        P.Gendor,L.IssueDate,L.Notes,L.IsActive,
                        P.DateOfBirth,L.DriverID,L.ExpirationDate,L.IssueReason, P.ImagePath
                        from Licenses L
                        join Drivers D on L.DriverID=D.DriverID
                        join People P on P.PersonID=D.PersonID
                        join LicenseClasses LC on LC.LicenseClassID=L.LicenseClass
                        where LicenseID=@LicenseID";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                 dtInfo.Load(reader);
                
                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return dtInfo;
        }

        public static bool IsLicenseDetained(int licenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select found=1 from DetainedLicenses 
                    where LicenseID=@LicenseID and IsReleased=0";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

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

        public static int GetLicenseIDByLDLAppID(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select licenseID from Licenses L
                join Applications A on A.ApplicationID=L.ApplicationID
                join LocalDrivingLicenseApplications LD on LD.ApplicationID=A.ApplicationID
                where LD.LocalDrivingLicenseApplicationID=@LDLAppID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int licenseID))
                    return licenseID;

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }

        public static bool DeactivateLicense(int licenseID)
        {
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"update Licenses
                set IsActive=@IsActive
                where LicenseID=@LicenseID";

            SqlCommand cmd= new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            cmd.Parameters.AddWithValue("@IsActive", false);

            try
            {
                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    return true;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }

        public static DataTable GetAllLocalLicensesPerPerson(int personID)
        {
            DataTable dt= new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select LicenseID,A.ApplicationID,LC.ClassName,L.IssueDate,L.ExpirationDate,L.IsActive from Licenses L
                join Applications A on A.ApplicationID=L.ApplicationID
                join LicenseClasses LC on LC.LicenseClassID=L.LicenseClass
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

        public static bool FindLicenseByID(int licenseID, ref int appID, ref int driverID,ref int licenseClass, ref DateTime issueDate,
            ref DateTime expirationDate, ref string notes,ref float paidFees,ref bool isActive,ref byte issueReason,ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from Licenses where LicenseID=@LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    appID = Convert.ToInt32(reader["ApplicationID"]);
                    driverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    notes = reader["Notes"].ToString();
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToByte(reader["IssueReason"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { connection.Close(); }
            return false;
        } 
    }
}
