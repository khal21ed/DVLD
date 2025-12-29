using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Business.clsPerson;

namespace Business
{
    public class clsPerson
    {
        public enum enGender
        {
            Male=0,
            Female=1
        }   

        public enum enMode
        {
            AddNew=0,
            Update=1
        }

         enMode Mode = enMode.AddNew;
        public int Id { get; }
        public string NationalNo {  get; set; }
        public string FirstName { get; set; }
        public string SecondName {  get; set; }
        public string ThirdName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address {  get; set; }
        public enGender Gender {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Country { get; set; }

        public clsPerson()
        {
            Id = -1;

            Mode = enMode.AddNew;

            NationalNo=string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            Country = 0;

            Gender = enGender.Male;         
            DateOfBirth = DateTime.Today;   
        }
        
        clsPerson(int id,string nationalNo, string firstName, string secondName, string thirdName, string lastName, string email, string phone, string address, 
            enGender gendor, DateTime dateOfBirth, int country)
        {
            Id = id;
            NationalNo=nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            Gender = gendor;
            DateOfBirth = dateOfBirth;
            Country = country;
        }

        public static DataTable getAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static DataTable getPeopleFilterdBy(string columnName, string searchValue)
        {
            return clsPersonData.GetPeopleFilteredBy(columnName, searchValue);
        }
        public static bool PersonExistsByNationalNo(string nationalNo)
        {
            return clsPersonData.PersonExistsByNationalNo(nationalNo);
        }

        //private bool _AddNewPerson()
        //{
        //}
        //public bool Save()
        //{
        //    if (Mode == enMode.AddNew)
        //    {
               
        //    }
        //}

    }
}
