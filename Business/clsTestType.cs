using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, PracticalTest = 3 };

        public int ID { get; private set; }
        public string Title { get;set; }
        public string Description { get; set; }
        public int Fees { get; set; }

        clsTestType(int id, string title, string description, int fees)
        {
            ID = id;
            Title = title;
            Description = description;
            Fees = fees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesAccess.GetAllTestTypes();
        }

        public static clsTestType FindTestTypeByID(int id) 
        {
            string title=string.Empty, description=string.Empty;int fees=0;
            if (clsTestTypesAccess.FindTestTypeByID(id, ref title, ref description, ref fees)) 
                 return new clsTestType(id, title, description, fees);

            return null;
                    
        }

        public bool UpdateTestType()
        {
            return clsTestTypesAccess.UpdateTestType(ID, Title, Description, Fees);
        }

        public static float GetTestTypeFees(int testTypeID)
        {
            return clsTestTypesAccess.GetApplicationTypeFeesByID(testTypeID);
        }
    }
}
