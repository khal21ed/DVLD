using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.clsLicense;

namespace Business
{
    public class clsLicense
    { 
        public enum enIssueReason {FirstTime=1,Renew=2,ReplacementForDamaged=3,
            ReplacementForLost=4 }
        public int ID { get; private set; }
        public int ApplicationID {  get;  set; }
        public int DriverID {  get; set; }
        public int LicenseClassID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public string Notes {  get; set; }
        public float PaidFees {  get; set; }
        public bool IsActive {  get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID {  get; set; }

        public clsLicense()
        {
            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate=DateTime.MinValue;
            ExpirationDate=DateTime.MinValue;
            Notes = string.Empty;
           PaidFees = 0;
            IsActive = false;
            CreatedByUserID = -1;
        }
        private clsLicense(int iD, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes,
            float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            ID = iD;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }

        public static bool HasLicenseByLDLAppID(int LDLAppID)
        {
            return clsLicenseAccess.HasLicenseForApplicatoin(LDLAppID);
        }
        public static clsLicenseCardInfo GetLicenseCardInfo(int licenseID)
        {
            DataTable dt = clsLicenseAccess.GetLicenseInfo(licenseID);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new clsLicenseCardInfo
            {
                FullName = row["FullName"].ToString(),
                ClassName = row["ClassName"].ToString(),
                LicenseID = Convert.ToInt32(row["LicenseID"]),
                NationalNo = row["NationalNo"].ToString(),
                Gender = (clsPerson.enGender)Convert.ToByte(row["Gendor"]),//In DB it's written Gendor
                IssueDate = Convert.ToDateTime(row["IssueDate"]),
                IssueReason = (enIssueReason)Convert.ToByte(row["IssueReason"]),
                Notes = row["Notes"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                DriverID = Convert.ToInt32(row["DriverID"]),
                ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]),
                ImagePath = row["ImagePath"] == DBNull.Value ? null : row["ImagePath"].ToString(),
                IsDetained = clsLicense.IsLicenseDetaind(licenseID)
            };
        }
        public bool IssueLicense(int personID)
        {
            DriverID=clsDriver.GetDriverIDByPersonID(personID);
            if (DriverID == -1)
                return false;

          this.ID=  clsLicenseAccess.AddNewDrivingLicense(ApplicationID,DriverID,LicenseClassID,
                IssueDate,ExpirationDate,Notes,PaidFees,IsActive,(byte)IssueReason,CreatedByUserID);

            return (ID != -1);
        }
        public bool DeactivateLicense()
        {
            this.IsActive = false;
            return clsLicenseAccess.DeactivateLicense(this.ID);
        }
        public static clsLicense FindLicenseByID(int licenseID)
        {
            int applicationID = -1, driverID = -1, licenseClassID = -1, createdByUserID = -1;
            float paidFees = 0;
            bool isActive = false;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            byte issueReason = 0;
            string notes = "";

            if (clsLicenseAccess.FindLicenseByID(licenseID,
                ref applicationID, ref driverID, ref licenseClassID, ref issueDate,
                ref expirationDate, ref notes, ref paidFees, ref isActive,
                ref issueReason, ref createdByUserID))
            
                return new clsLicense(licenseID, applicationID, driverID, licenseClassID,
                    issueDate, expirationDate, notes, paidFees, isActive,
                    (enIssueReason)issueReason, createdByUserID);
            return null;
        }
        public static bool IsLicenseDetaind(int licenseID)
        {
            return clsLicenseAccess.IsLicenseDetained(licenseID);
        }
        public static int GetLicenseIDByLDLAppID(int LDLAppID)
        {
            return clsLicenseAccess.GetLicenseIDByLDLAppID(LDLAppID);
        }      
        public static DataTable GetAllLocalLicensesPerPerson(int personID)
        {
            return clsLicenseAccess.GetAllLocalLicensesPerPerson(personID);
        }
    }
}
