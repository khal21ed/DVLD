using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class clsLocalDrivingLicenseAppAccess
    {
        public static DataTable GetAllLocalLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select * from LDLAWithPersonAndTestsPassed_View";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return dt;
        }
        public static bool FindLocalDrivingLicenseAppByID(int localAppID, ref int appID, ref int licenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from LocalDrivingLicenseApplications
                            where LocalDrivingLicenseApplicationID =@LDLAppID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", localAppID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    appID = Convert.ToInt32(reader["ApplicationID"]);
                    licenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                    reader.Close();
                    return true;
                }
                reader.Close();
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }
        public static bool PersonHasLDLAWithSameClassAndInTheGivenStatus(int personID, byte appStatus, int licenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select found =1 from LocalDrivingLicenseApplications LApp
                            join Applications App on App.ApplicationID = LApp.ApplicationID
                            where App.ApplicationStatus =@ApplicationStatus
                            and app.ApplicantPersonID =@PersonID
                            and LicenseClassID=@LicenseClassID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", appStatus);

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
        public static int AddNewLDLApp(int appID, int classID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into LocalDrivingLicenseApplications(ApplicationID,
                            LicenseClassID)
                            Values(@ApplicationID,@LicenseClassID)
                            select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", appID);
            cmd.Parameters.AddWithValue("@LicenseClassID", classID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LDLAppID))
                {

                    return LDLAppID;
                }
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }
        public static bool UpdateLDLApp(int LDLAppID, int classID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Update LocalDrivingLicenseApplications
                            Set LicenseClassID=@LicenseClassID
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseClassID", classID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);

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
        public static bool CancelLDLApp(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE App
                            SET App.ApplicationStatus = 2
                            FROM Applications App
                            JOIN LocalDrivingLicenseApplications LDLA
                                ON App.ApplicationID = LDLA.ApplicationID
                            WHERE LDLA.LocalDrivingLicenseApplicationID = @LDLAppID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

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
        public static byte GetNumberOfTestsPassed(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT COUNT(*) AS PassedTests
                            FROM TestAppointments TA
                            JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
                            WHERE TA.LocalDrivingLicenseApplicationID = @LDLAppID
                              AND T.TestResult = 1;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                object resutl = cmd.ExecuteScalar();

                if (resutl != null && byte.TryParse(resutl.ToString(), out byte passedTests))
                    return passedTests;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return 0;
        }

        public static bool ChangeApplicationStatus(int LDLAppID, byte status)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"UPDATE App
                            SET App.ApplicationStatus = @ApplicationStatus
                            FROM Applications App
                            JOIN LocalDrivingLicenseApplications LDLA
                                ON App.ApplicationID = LDLA.ApplicationID
                            WHERE LDLA.LocalDrivingLicenseApplicationID = @LDLAppID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", status);

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

        public static bool DeleteLDLApp(int LDLAppID, int appID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"
                        delete from LocalDrivingLicenseApplications
                        where LocalDrivingLicenseApplicationID=@LDLAppID

                        delete from Applications
                        where ApplicationID=@ApplicationID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@ApplicationID", appID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return true;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }

        public static int GetPersonIDByLDLAppID(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT TOP (1) A.ApplicantPersonID from LocalDrivingLicenseApplications LD
                        join Applications A on A.ApplicationID = LD.ApplicationID
                        where LD.LocalDrivingLicenseApplicationID=@LDLAppID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int personID))
                    return personID;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }

        public static bool LDLAppHasAppointments(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select top 1 found=1 from TestAppointments
                where LocalDrivingLicenseApplicationID=@LDLAppID";
            SqlCommand cmd = new SqlCommand(query,connection);
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
    }
}
