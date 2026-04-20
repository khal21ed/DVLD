using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsTestAccess
    {
        public static int AddNewTest(int testAppointmentID,bool testResult,string notes,
            int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID)
                            values(@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID)
                            select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", testResult);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            if(string.IsNullOrWhiteSpace(notes))
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Notes", notes);

            try
            {
                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int testID))
                        return testID;
                }
                catch (Exception ex) { throw; }
                finally { connection.Close(); }
            return -1;
        }
    }
}
