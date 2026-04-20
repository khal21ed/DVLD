using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsDriver
    {
        public int ID {  get; private set; }
        public int PersonID {  get;  set; }
        public int CreatedByUserID {  get; set; }
        public DateTime CreatedDate { get; set; }

        public bool AddNewDriver()
        {
            this.ID = clsDriverAccess.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            return (this.ID != -1);
        }

        public static int GetDriverIDByPersonID(int personID)
        {
            return clsDriverAccess.GetDriverIDByPersonID(personID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverAccess.GetAllDrivers();
        }
    }
}
