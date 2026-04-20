using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace DVLD
{
    internal class clsSessoin
    {
        public static clsUser CurrentUser;
        public static bool IsFirstLogin = true;
        public static void Login(clsUser user)
        {
            CurrentUser = user;
            
        }
        public static void Logout(clsUser user)
        {
            CurrentUser=null;
        }

    }
}
