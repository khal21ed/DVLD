using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsLicenseCardInfo
    {
        public string ClassName {  get; set; }
        public string FullName {  get; set; }
        public int LicenseID {  get; set; }
        public string NationalNo {  get; set; }
        public clsPerson.enGender Gender { get; set; }
        public DateTime IssueDate {  get; set; }
        public clsLicense.enIssueReason IssueReason {  get; set; }
        public string Notes {  get; set; }
        public bool IsActive {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public int DriverID {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public string ImagePath { get; set; }
        public bool IsDetained {  get; set; }

    }
}
