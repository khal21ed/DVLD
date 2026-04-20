using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        public void LoadUser(clsUser user)
        {
            ctrlShowPersonInfo1.LoadPerson(user.PersonID);
            lblUserIDValue.Text=user.ID.ToString();
            lblUserNameValue.Text=user.UserName;
            lblIsActiveValue.Text = user.IsActive ? "Yes" : "No";
        }
        
    }
}
