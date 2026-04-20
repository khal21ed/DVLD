using System;

namespace Business
{
    
        public class clsInternationalLicenseCardInfo
        {
            public int IntLicenseID { get; set; }
            public int ApplicationID { get; set; }
            public int IssuedUsingLocalLicenseID { get; set; }
            public bool IsActive { get; set; }
            public string NationalNo { get; set; }
            public string FullName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public clsPerson.enGender Gender { get; set; } 
            public int DriverID { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string ImagePath { get; set; }
        }

    
}
