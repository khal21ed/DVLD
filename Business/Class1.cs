using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class clsPerson
    {
        public static DataTable getAllPeople()
        {
            return clsDataAccess.getAllPeople();
        }
        public static DataTable getPeopleFilterdBy(string columnName, string searchValue)
        {
            return clsDataAccess.getPeopleFilteredBy(columnName, searchValue);
        }
    }
}
