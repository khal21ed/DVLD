using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsApplicationTypes
    {
        public enum enApplicatoinType
        {
            NewInternationalLicense = 1, NewLocalDrivingLicense = 2,
            ReleaseDetainedDrivingLicense = 3, RenewDrivingLicense = 4, ReplacementForDamagedDL = 5,
            ReplacementForLostDL = 6, RetakeTest = 7
        }
        public int ApplicatoinID { get; private set; }
        public string Title {  get;  set; }
        public float Fees {  get; set; }

        private clsApplicationTypes(int applicatoinID, string title,float fees)
        {
            ApplicatoinID = applicatoinID;
            Title = title;
            Fees = fees;
        }

        public static string ApplicationTypeToText(enApplicatoinType appType)
        {
            switch (appType)
            {
                case enApplicatoinType.NewInternationalLicense:
                    return "New International License";
                case enApplicatoinType.NewLocalDrivingLicense:
                    return "New Local Driving License";
                case enApplicatoinType.ReleaseDetainedDrivingLicense:
                    return "Release Detained Driving License";
                case enApplicatoinType.RenewDrivingLicense:
                    return "Renew Driving License";
                case enApplicatoinType.ReplacementForDamagedDL:
                    return "Replacement For Damaged Driving License";
                case enApplicatoinType.ReplacementForLostDL:
                    return "Replacement For Lost Driving License";
                case enApplicatoinType.RetakeTest:
                    return "Retake Test";
                default:
                    return "Unknown";
            }
        }
        public static DataTable GetApplicationTypes()
        {
            return clsApplicationTypesAccess.GetAllApplicatoinTypes();
        }

        public static clsApplicationTypes FindApplicationTypeByID(int id)
        {
            string title = "";float fees=0;
           if( clsApplicationTypesAccess.FindApplicationType(id,ref title,ref fees))
                return new clsApplicationTypes(id,title,fees);
            return null;
        }
        public bool UpdateApplicationType()
        {
            return clsApplicationTypesAccess.UpdateApplicatoinType(ApplicatoinID, Title, Fees);
        }
        public static float GetApplicatoinTypeFee(enApplicatoinType appType)
        {
            return clsApplicationTypesAccess.GetApplicationTypeFee((byte)appType);
        }
    }
}
