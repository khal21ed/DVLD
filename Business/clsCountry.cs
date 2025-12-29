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
            return clsCountryData.findCountryByName(countryName);
        }
        public static DataTable getAllCountryNames()
        {
            return clsCountryData.getAllCountryNames();
        }
    }
}
