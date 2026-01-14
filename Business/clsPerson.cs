using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Business.clsPerson;
using System.IO;

namespace Business
{
    public class clsPerson
    {
        public enum enGender : byte
        {
            Male=0,
            Female=1
        }   
        public enum enMode : byte
        {
            AddNew=0,
            Update=1
        }

        private enMode Mode;
        public int Id { get; set; }
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
        public string ImagePath {  get; set; }

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
            Country = -1;

            Gender = enGender.Male;         
            DateOfBirth = DateTime.Today;   
            ImagePath= string.Empty;
        } 
        private clsPerson(int id,string nationalNo, string firstName, string secondName, string thirdName, string lastName, string email, string phone, string address, 
            enGender gendor, DateTime dateOfBirth, int country,string imagePath)
        {
            Mode = enMode.Update;
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
            ImagePath= imagePath;
        }
        private void _SaveImageOnDifferentDirectory()
        {


            //To delete the person's old image in the images folder
            if (Mode == enMode.Update)
            {
                clsPerson personBeforeUpdating = FindPersonByID(this.Id);

                if (string.IsNullOrEmpty(personBeforeUpdating.ImagePath)
                || personBeforeUpdating.ImagePath == ImagePath)
                    return;

                File.Delete(personBeforeUpdating.ImagePath);
            }

            if (string.IsNullOrWhiteSpace(ImagePath))
                return;

            string sourcePath = ImagePath;
            string targetFolder = @"C:\DVLD-People-Images";

            string extension = Path.GetExtension(sourcePath);
            string fileName=Guid.NewGuid().ToString() + extension;
            string targetPath=Path.Combine(targetFolder, fileName);

            File.Copy(sourcePath, targetPath, true);
            ImagePath = targetPath;
          
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
        public static clsPerson FindPersonByID(int ID)
        {
            string nationalNumber = ""; string firstName = ""; string secondName = ""; string thirdName = ""; string lastName = ""; DateTime dateOfBirth=DateTime.MinValue;
            string address = ""; string phone = ""; byte gender = 0; string email = ""; int country = 0; string imagepath = "";

            if (clsPersonData.GetPersonInfoByID(ID, ref nationalNumber, ref firstName, ref secondName, ref thirdName, ref lastName,
                ref dateOfBirth, ref address, ref phone, ref gender, ref email, ref country, ref imagepath)) 
                return (new clsPerson(ID,nationalNumber,firstName,secondName,thirdName,lastName, 
                  email, address, phone, (enGender)gender, dateOfBirth, country, imagepath));
            return null;
        }
        private bool _AddNewPerson()
        {
            _SaveImageOnDifferentDirectory();

            this.Id= clsPersonData.AddNewPerson(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
                Address,Phone, (byte)Gender,Email,Country,ImagePath);
            if (this.Id != -1)
                return true;

            return false;
        }
        private bool _UpdatePerson()
        {
            _SaveImageOnDifferentDirectory();
            return clsPersonData.UpdatePerson(Id, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                                    Address, Phone, (byte)Gender, Email, Country, ImagePath);
        }
        public static void DeletePerson(int personID) 
        {
            try {
                clsPerson person = FindPersonByID(personID);

                clsPersonData.DeletePerson(personID);

                if (person != null && !string.IsNullOrEmpty(person.ImagePath))
                    File.Delete(person.ImagePath);
            }
            catch (Exception ex) { throw; }
        }
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewPerson())
                {
                    Mode = enMode.Update;
                    return true;
                }
            }

            else if (Mode== enMode.Update)
            {
                return _UpdatePerson();
            }
            return false;
        }

    }
}
