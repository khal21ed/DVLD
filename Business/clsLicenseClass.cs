using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsLicenseClass
    {
        public static DataTable GetAllLicenseClassNames()
        {
            return clsLicenseClassAccess.GetAllLicenseClassNames();
        }
        public static string GetLicenseClassNameByID(int licenseClassID)
        {
            return clsLicenseClassAccess.GetLicenseClassNameByID(licenseClassID);
        }
        public static int GetLicenseClassValidatyLength(int licenseClassID)
        {
            return clsLicenseClassAccess.GetLicenseClassValidatyLength(licenseClassID);
        }
        public static float GetLicenseClassFees(int licenseClassID)
        {
            return clsLicenseClassAccess.GetLicenseClassPaidFees(licenseClassID);
        }
    }
}
