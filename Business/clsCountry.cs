using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsCountry
    {
        public static int findCountryByName(string countryName)
        {
            return clsCountryData.FindCountryByName(countryName);
        }
        public static DataTable getAllCountryNames()
        {
            return clsCountryData.GetAllCountryNames();
        }

        public static string FindCountryByID(int id)
        {
            return clsCountryData.FindCountryByCountryID(id)??"";
        }
    }
}
