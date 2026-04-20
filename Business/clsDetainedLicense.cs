using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsDetainedLicense
    {
        public int DetainID {  get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate {  get; set; }
        public float FineFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public bool IsReleased {  get; set; }
        public DateTime ReleaseDate {  get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID{get; set; }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

        }

        private clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, 
            float fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }
       
        public static clsDetainedLicense Find(int licenseID)
        {
            int detainID = -1, createdByUserID = -1,releaseAppID= -1,releaseByUserID=-1;
            DateTime detainDate= DateTime.MinValue,releaseDate=DateTime.MinValue;
            bool isReleased=false;
            float fineFees=0;

            if (clsDetainedLicenseAccess.FindDetainedLicense(licenseID, ref detainID, ref detainDate, ref fineFees,
               ref createdByUserID, ref isReleased, ref releaseDate, ref releaseByUserID, ref releaseAppID))
                return new clsDetainedLicense(detainID, licenseID, detainDate, fineFees, createdByUserID,
                    isReleased, releaseDate, releaseByUserID, releaseAppID);
            return null;
        }

        public bool AddNewDetainedLicense()
        {
           this.DetainID= clsDetainedLicenseAccess.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID);
            return (this.DetainID != -1);
        }
        public bool ReleaseDetainedLicense()
        {
            return clsDetainedLicenseAccess.ReleaseDetainedLicense(DetainID, ReleaseDate, ReleasedByUserID,
                ReleaseApplicationID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseAccess.GetDetainedLicenses();
        }
    }
}
