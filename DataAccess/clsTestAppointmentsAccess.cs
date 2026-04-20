using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsTestAppointmentsAccess
    {
        public static DataTable GetAllTestAppointmentsFiltered(int LDLAppID,int testTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"  select TestAppointmentID,AppointmentDate,PaidFees,IsLocked
                                from TestAppointments
                                where LocalDrivingLicenseApplicationID=@LDLAppID 
                                and TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);

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

        public static int GetNumberOfAppointmentsFilteredBy(int LDLAppID,int testTypeID,bool isLocked)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT COUNT(*) AS TrialCount
                            FROM TestAppointments
                            WHERE LocalDrivingLicenseApplicationID = @LDLAppID
                              AND TestTypeID = @TestTypeID and IsLocked=@IsLocked";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
            cmd.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if(result!=null && int.TryParse(result.ToString(), out int trials))
                        return trials;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return 0;
        }

        public static int AddNewTestAppointment(int testTypeID, int LDLAppID, DateTime appointmentDate
            , float paidFees, int CreatedByUserID, bool isLocked, int retakeTestAppID)
        {
            {
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                string query = @"  insert into TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate
                          ,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                          values(@TestTypeID, @LDLAppID, @AppointmentDate, @PaidFees,
                            @CreatedByUserID, @IsLocked, @RetakeTestApplicationID)
                            select Scope_Identity()";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                cmd.Parameters.AddWithValue("@PaidFees", paidFees);
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                cmd.Parameters.AddWithValue("@IsLocked", isLocked);
                if(retakeTestAppID==-1)
                    cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestAppID);


                try
                {
                        connection.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int appointmentID))
                            return appointmentID;
                    }
                    catch (Exception ex) { throw; }
                    finally { connection.Close(); }
                return -1;
            }
        }

        public static bool FindTestAppointmentByID( int appointmentID,ref int testTypeID, 
            ref int LDLAppID,ref DateTime appointmentDate
            ,ref float paidFees,ref int CreatedByUserID,ref bool isLocked, ref int retakeTestAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from TestAppointments
                            where TestAppointmentID=@TestAppointmentID";
            SqlCommand cmd =new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", appointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    testTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    LDLAppID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isLocked = Convert.ToBoolean(reader["IsLocked"]);
                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        retakeTestAppID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                    }
                    return true;
                }
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
            }

        public static bool ReschedualAppointment(int appointmentID,DateTime newAppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"update TestAppointments
                            set AppointmentDate=@AppointmentDate
                            where TestAppointmentID =@TestAppointmentID ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@AppointmentDate", newAppointmentDate);
            cmd.Parameters.AddWithValue("@TestAppointmentID", appointmentID);

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
        public static bool HasPassedTest(int LDLAppID,int testType)
        {
            SqlConnection connectino = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT COUNT(*) 
                     FROM TestAppointments ta
                     INNER JOIN Tests t ON ta.TestAppointmentID = t.TestAppointmentID
                     WHERE ta.LocalDrivingLicenseApplicationID = @LDLApplicationID 
                       AND ta.TestTypeID = @TestTypeID
                       AND t.TestResult = 1";

            SqlCommand cmd = new SqlCommand(query, connectino);
            cmd.Parameters.AddWithValue("@LDLApplicationID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", testType);

            try
            {
                connectino.Open();
                object result = cmd.ExecuteScalar();
                if (result != null &&
                    (int.Parse(result.ToString())) != 0)
                    return true;
                    
            }
            catch (Exception ex) { throw; }
            finally { connectino.Close(); }
            return false;
        }

        public static bool LockAppointment(int appointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"Update TestAppointments
                            set IsLocked=1 where TestAppointmentID=@TestAppointmentID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", appointmentID);

            try
            {
                connection.Open();
                int rawsAffected = cmd.ExecuteNonQuery();
                if (rawsAffected != 0)
                    return true;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return false;
        }
    }
}

