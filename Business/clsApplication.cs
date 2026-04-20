using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business
{
    public class clsApplication
    {
        public enum enApplicationStatus { New=1,Cancelled=2,Completed=3}
        public enum enMode { Add=1,Update=2 }
        public int ID {  get;private set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicatoinDate {  get; set; }
        public int ApplicationTypeID {  get; set; }
        public DateTime LastStatusDate {  get; set; }
        public float PaidFees {  get; set; }
        public int CreatedByUser {  get; set; }
        public enApplicationStatus Status { get;  set; }

        public clsApplication()
        {
            ID = -1;
            ApplicantPersonID = -1;
            ApplicationTypeID = -1;
            ApplicatoinDate = DateTime.Now;
            LastStatusDate= DateTime.Now;
            PaidFees = 0;
            CreatedByUser = -1;
            Status=enApplicationStatus.New;

        }
        public clsApplication(int appID,int applicantPersonID, DateTime applicatoinDate, 
            int applicationTypeID, DateTime lastStatusDate, float paidFees, int createdByUser, enApplicationStatus status)
        {
            ID = appID;
            ApplicantPersonID = applicantPersonID;
            ApplicatoinDate = applicatoinDate;
            ApplicationTypeID = applicationTypeID;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUser = createdByUser;
            Status = status;
        }

        public bool AddNewApplication()
        {
            this.ID = clsApplicationAccess.AddNewApplicatoin(ApplicantPersonID, ApplicatoinDate,
                 ApplicationTypeID, (byte)Status, LastStatusDate, PaidFees,CreatedByUser);

            return (ID != -1);
        }

        public static clsApplication FindApplicationByID(int appID) 
        {
            int appPersonID=-1, createdByUser=-1,appTypeID = -1;
            float paidFees = 0;
            DateTime appDate=DateTime.MinValue, lastStatusDate = DateTime.MinValue;
            byte appStatus = 0;

            if (clsApplicationAccess.FindApplicationByID(appID, ref appPersonID, ref appDate, ref appTypeID, ref appStatus,
           ref lastStatusDate, ref paidFees, ref createdByUser))
                return new clsApplication(appID,appPersonID,appDate,appTypeID,
                    lastStatusDate,paidFees,createdByUser,(enApplicationStatus)appStatus);

            return null;
        }
    }
}
