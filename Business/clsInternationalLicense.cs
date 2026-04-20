using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.clsInternationalLicenseCardInfo;

namespace Business
{
    public class clsInternationalLicense
    {
        public int ID {  get; private set; }
        public int ApplicationID {  get; set; }
        public int DriverID {  get; set; }
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpiratinoDate {  get; set; }
        public bool IsActive {  get; set; }
        public int CreatedByUserID {  get; set; }

        public static DataTable GetAllInternationalLicensesPerPerson(int personID)
        {
            return clsInternationalLicenseAccess.GetAllInternationalLicensesPerPerson(personID);
        }
        public static bool HasInternationalLicenseByLDLID(int localLicenseID,out int intLicenseID)
        {
            if (clsInternationalLicenseAccess.HasInternationalLicenseByLDLID(localLicenseID) != -1)
            {
                intLicenseID = localLicenseID;
                return true;
            }
            intLicenseID = -1;
            return false;
        }
        public bool IssueDrivingLicense() 
        {
            this.ID = clsInternationalLicenseAccess.AddInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpiratinoDate, IsActive, CreatedByUserID);
            return (ID != -1);
        }

        public static clsInternationalLicenseCardInfo GetInternationalLicenseCardInfoDTO(int intLicenseID)
        {
            DataTable dt = clsInternationalLicenseAccess.GetInternationalLicenseCardInfo(intLicenseID);

            if (dt == null || dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsInternationalLicenseCardInfo
            {
                IntLicenseID = Convert.ToInt32(row["IntLicenseID"]),
                ApplicationID = Convert.ToInt32(row["ApplicationID"]),
                IssuedUsingLocalLicenseID = Convert.ToInt32(row["IssuedUsingLocalLicenseID"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),

                NationalNo = row["NationalNo"]?.ToString(),
                FullName = row["FullName"]?.ToString(),

                DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                Gender = (clsPerson.enGender)Convert.ToByte(row["Gendor"]),

                DriverID = Convert.ToInt32(row["DriverID"]),
                IssueDate = Convert.ToDateTime(row["IssueDate"]),
                ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]),

                ImagePath = row["ImagePath"] == DBNull.Value ? null : row["ImagePath"].ToString()
            };
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseAccess.GetAllInternationalLicenses();
        }

    }
}
