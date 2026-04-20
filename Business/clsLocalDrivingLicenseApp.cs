using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsLocalDrivingLicenseApp
    {
        public enum enMode { AddNew=1,Update=2};
        public enMode Mode { get; private set; }
        public int LDLAID {  get; private set; }
        public int ApplicationID {  get;  set; }
        public int LicenseClassID {  get;  set; }
        public clsApplication Application { get; set; } = new clsApplication();

        public clsLocalDrivingLicenseApp()
        {
            Mode=enMode.AddNew;
            LDLAID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }
        private clsLocalDrivingLicenseApp(int iD, int applicationID, int licenseClassID)
        {
            Mode=enMode.Update;
            LDLAID = iD;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }

        public void LoadApplication()
        {
           Application= clsApplication.FindApplicationByID(ApplicationID);
        }
        public static DataTable GetAllLocalDrivingLicenses()
        {
            return clsLocalDrivingLicenseAppAccess.GetAllLocalLicenseApplications();
        }
        public static clsLocalDrivingLicenseApp FindLocalDrivingLicenseApp(int localAppID)
        {
            int appID = -1,licenseClass= -1;
            if(clsLocalDrivingLicenseAppAccess.FindLocalDrivingLicenseAppByID(localAppID,ref appID,ref licenseClass))
            {
                return new clsLocalDrivingLicenseApp(localAppID,appID,licenseClass);
            }
            return null;
        }
        public static bool PersonHasLDLAWithSameClassAndInNewStatus(int personID,int licenseClass)
        {
            return clsLocalDrivingLicenseAppAccess.
                PersonHasLDLAWithSameClassAndInTheGivenStatus(personID,(byte)clsApplication.enApplicationStatus.New,licenseClass);
        }
        public static bool PersonHasLDLAWithSameClassAndInCompletedStatus(int personID, int licenseClass)
        {
            return clsLocalDrivingLicenseAppAccess.
                PersonHasLDLAWithSameClassAndInTheGivenStatus(personID, (byte)clsApplication.enApplicationStatus.Completed, licenseClass);
        }

        private bool _AddNewLDLA()
        {
            if (Application.AddNewApplication())
            {
                ApplicationID = Application.ID;
                this.LDLAID = clsLocalDrivingLicenseAppAccess.AddNewLDLApp(ApplicationID, LicenseClassID);
                if(LDLAID!=-1)
                    return true;
                return false;
            }
            return false;
        }
        private bool _UpdateLDLA()
        {
            return clsLocalDrivingLicenseAppAccess.UpdateLDLApp(LDLAID, LicenseClassID);
        }
        public byte GetNumberOfTestsPassed()
        {
            return clsLocalDrivingLicenseAppAccess.GetNumberOfTestsPassed(LDLAID);
        }

        public static bool CancelLDLApp(int LDLAppID)
        {
            return clsLocalDrivingLicenseAppAccess.CancelLDLApp(LDLAppID);
        }
        public static bool ChangeApplicationStatus(int LDLAppID,clsApplication.enApplicationStatus status)
        {
            return clsLocalDrivingLicenseAppAccess.ChangeApplicationStatus(LDLAppID, (byte)status);
        }
        public static bool DeleteLDLApp(int LDLAppID)
        {
            clsLocalDrivingLicenseApp LDLApp=clsLocalDrivingLicenseApp.FindLocalDrivingLicenseApp(LDLAppID);
            if (LDLApp == null)
                return false;
        
                return clsLocalDrivingLicenseAppAccess.DeleteLDLApp(LDLAppID, LDLApp.ApplicationID);

        }
        public static int GetPersonIDByLDLAppID(int LDLAppID)
        {
            return clsLocalDrivingLicenseAppAccess.GetPersonIDByLDLAppID(LDLAppID);
        }
        public static bool LDLAppHasAppointments(int LDLAppID)
        {
            return clsLocalDrivingLicenseAppAccess.LDLAppHasAppointments(LDLAppID) ;
        }
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if(_AddNewLDLA())
                {
                    Mode = enMode.Update;
                    return true;
                }
            }
            else 
            {
                if(_UpdateLDLA())
                    return true;
            }
            return false;
        }
    }
}
