using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsDriverAccess
    {
        public static int AddNewDriver(int personID,int createdByUserID,DateTime createDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into Drivers
                    Values(@PersonID,@CreatedByUserID,@CreatedDate)
                    select SCOPE_IDENTITY() ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", createDate);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int driverID))
                {
                    return driverID;
                }

            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }

        public static int GetDriverIDByPersonID(int personID)
        {
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select DriverID from Drivers
                            where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null&&int.TryParse(result.ToString(),out int driverID))
                    return driverID;
            }
            catch(Exception ex) { throw; }
            finally { connection.Close(); }
            return -1;
        }
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection=new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select D.DriverID,P.PersonID,P.NationalNo,P.FirstName+' '+P.SecondName+
            case when P.ThirdName is not null then ' '+P.ThirdName+' ' else ' 'end+p.LastName as FullName,
            D.CreatedDate,sum(case when L.IsActive=1 then 1 else 0 end) as ActiveLicenses
            from Drivers as D
            join People as P on D.PersonID=P.PersonID
            join Licenses as L on L.DriverID = D.DriverID
            group by D.DriverID,P.PersonID,
            P.NationalNo,P.FirstName,P.SecondName,P.ThirdName,
            P.LastName,D.CreatedDate";

            SqlCommand cmd = new SqlCommand(query,connection);
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
    }
}
