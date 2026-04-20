using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public  class clsTestAppointment
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode Mode { get;  set; }
        public int ID { get; private set; }
        public int TestTypeID { get; set; }
        public int LDLAppID {  get; set; }
        public DateTime AppointmentDate {  get; set; }
        public float PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public bool IsLocked {  get; set; }
        public int RetakeTestApplicationID {  get; set; }

        public clsTestAppointment()
        {
            Mode = enMode.AddNew;
            ID = -1;
            TestTypeID =-1;
            LDLAppID = -1;
            AppointmentDate = DateTime.MinValue;
            PaidFees = 0;
            CreatedByUserID = 0;
            IsLocked = false;
            RetakeTestApplicationID = -1;
        }
        private clsTestAppointment(int iD, int testTypeID, int lDLAppID, DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            Mode = enMode.Update;
            ID = iD;
            TestTypeID = testTypeID;
            LDLAppID = lDLAppID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
        }

        public static DataTable GetTestAppointmentsFilteredBy(int LDLAppID,int testTypeID)
        {
            return clsTestAppointmentsAccess.GetAllTestAppointmentsFiltered(LDLAppID, testTypeID);
        }
        public static int GetNumberOfTrials(int LDLAppID,int testTypeID)
        {
            return clsTestAppointmentsAccess.GetNumberOfAppointmentsFilteredBy(LDLAppID, testTypeID,true);
        }
        private bool _AddNewAppointment()
        {
            this.ID = clsTestAppointmentsAccess.AddNewTestAppointment(TestTypeID, LDLAppID, AppointmentDate,
                PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            if (ID != -1)
                return true;
            return false;
        }
        private bool _UpdateAppointment()
        {
            return clsTestAppointmentsAccess.ReschedualAppointment(ID, AppointmentDate);
        }
        public static clsTestAppointment FindAppointmentByID(int appointmentID)
        {
            int testTypeID = -1, LDLAppID = -1, retakeTestAppID = -1, createdByUserID = -1; DateTime appointmentDate = DateTime.MinValue;
            float paidFees = -1; bool isLocked = false;

            if (clsTestAppointmentsAccess.FindTestAppointmentByID(appointmentID, ref testTypeID, ref LDLAppID,
                ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestAppID))

                return new clsTestAppointment(appointmentID, testTypeID, LDLAppID, appointmentDate,
                    paidFees, createdByUserID, isLocked, retakeTestAppID);

            return null;
        }
        public static bool HasPassedTest(int LDLApp,int testTypeID)
        {
            return clsTestAppointmentsAccess.HasPassedTest(LDLApp,testTypeID);
        }
        public static bool HasActiveAppointment(int LDLApp,int testTypeID)
        {
            if (clsTestAppointmentsAccess.
                GetNumberOfAppointmentsFilteredBy(LDLApp, testTypeID, false)!=0)
                return true;
            return false;
        }
        public bool LockAppointment()
        {
            return clsTestAppointmentsAccess.LockAppointment(ID);
        }
        public bool Save()
        {
            if(Mode == enMode.AddNew)
            {
                if (_AddNewAppointment())
                {
                    Mode = enMode.Update;
                    return true;
                }
            }
            else if (Mode == enMode.Update)
            {
                if(_UpdateAppointment())
                    return true;
            }
            return false;
        }
    }
}
