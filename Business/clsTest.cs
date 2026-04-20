using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsTest
    {
        public int ID {  get;private set; }
        public int AppointmentID {  get; set; }
        public bool TestResult {  get; set; }
        public string Notes {  get; set; }
        public int CreatedByUserID {  get; set; }

        public clsTest()
        {
            ID = -1;
            AppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
        }
        public bool AddNewTest()
        {
           this.ID=clsTestAccess.AddNewTest(AppointmentID,TestResult,Notes,CreatedByUserID);
            
            return (ID!=-1);
        }
        
    }
}
