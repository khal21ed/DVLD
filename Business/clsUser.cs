using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.IO;
using System.Data;
using Microsoft.Win32;
using System.Runtime.Remoting.Messaging;

namespace Business
{
    public class clsUser
    {
        enum enMode { AddNew=0, Update=1}
        enMode Mode;

        public const string SavingToFileSeperator = "###";
        private static string _FilePath = Path.Combine(@"D:\C#-Projects\Course-19\DVLD", "remembered_user_loginInfo.txt");
        //These variables are for saving the remembered Username and Password on Windows Registory
        private static string _KeyPath = "HKEY_CURRENT_USER\\Software\\DVLD";
        private static string _SubKeyPath = "Software\\DVLD";
        private static string _KeyName = "UserName And Password";
        private static string _KeyValue ;

        public int ID { get; private set; }
        public int PersonID = -1;
        public clsPerson Person { get; set; }
        public string UserName { get; set; }
        public string Password {  get; set; }
        public bool IsActive {  get; set; }

       private clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            Mode= enMode.Update;
            ID = userID;
            PersonID = personID;
            this.Person = clsPerson.FindPersonByID(personID);
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }
        public clsUser()
        {
            ID = -1;
            Person = null;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive=false;
        }

        public static bool GetRememberedUser( out string loginInfo)
        {
            loginInfo = null;
            if (!File.Exists(_FilePath))
                return false;

            string savedLoginInf = File.ReadAllText(_FilePath);
            loginInfo = savedLoginInf;
            return !string.IsNullOrEmpty(savedLoginInf);
        }
        public static bool UserExistsByPersonID(int personID)
        {
            return clsUserAccess.UserExistsByPersonId(personID);
        }
        public static bool UserExistsByUserName(string userName)
        {
            return clsUserAccess.UserExistsByUserName(userName);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserAccess.GetAllUsers();
        }
        public void SaveUsernameAndPasswordToFile()
        {
            string loginInfo = $"{UserName}{SavingToFileSeperator}{Password}";
            File.WriteAllText(_FilePath,loginInfo);
        }
        public static void ForgetRememberedUser()
        {
            File.WriteAllText(_FilePath, string.Empty);
        }
        
        public bool SaveUsernameAndPasswordToWinRegistory()
        {
             _KeyValue = $"{UserName}{SavingToFileSeperator}{Password}";
            try
            {
                Registry.SetValue(_KeyPath,_KeyName,_KeyValue);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static void DeleteSavedUserInWinRegistory()
        {
            try { 
            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            {
                using (RegistryKey key = baseKey.OpenSubKey(_SubKeyPath, true))
                {
                    if (key != null)
                    {
                        // Delete the specified value
                        key.DeleteValue(_KeyName);

                    }
               
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
                throw ex;
        }

        }
        public static bool GetRememberedUserFromWinRegistory(out string loginInfo)
        {
            loginInfo = null;
            try
            {
                object value = Registry.GetValue(_KeyPath, _KeyName, null);
                if (value != null)
                {
                    loginInfo = value.ToString();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
        public static clsUser GetUserByUserNameAndPassword(string username,string password)
        {
            int userID = -1; bool isActive = false; int personID=-1;
            if (clsUserAccess.GetUserByUsernameAndPassword(username, password, ref userID, ref personID, ref isActive))
                return (new clsUser(userID, personID, username, password, isActive));

            return null;
        }
        public static clsUser FindUserByUserID(int userID)
        {
            string username=""; string password=""; bool isActive = false; int personID = -1;
            if (clsUserAccess.FindUserByUserID(userID, ref personID, ref username, ref password, ref isActive))
                return new clsUser(userID,personID, username, password, isActive);
            return null;
        }
        private bool _AddNewUser()
        {
            this.ID=clsUserAccess.AddUser(PersonID,UserName,Password,IsActive);
            return ID != -1 ? true : false;
        }
        private bool _UpdateUser()
        {
            return clsUserAccess.UpdateUser(ID,PersonID,UserName,Password,IsActive);
        }

        public static string GetUserNameByID(int userID)
        {
            return clsUserAccess.GetUserNameByUserID(userID);
        }
        public static void DeleteUser(int userID)
        {
            try
            {
                clsUserAccess.DeleteUser(userID);
            }
            catch { throw; }
        }
        public bool ChangePassword(string password)
        {
            if (clsUserAccess.ChangePassword(ID, password))
            {
                Password = password;
                return true;
            }
            return false;
        }
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewUser())
                {
                    Mode = enMode.Update;
                    return true;
                }
            }
            else if(Mode==enMode.Update)
            {
                return _UpdateUser();
            }
            return false;
        }

    }
}
