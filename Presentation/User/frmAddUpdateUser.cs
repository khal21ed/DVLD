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
    public partial class frmAddUpdateUser : Form
    {
        private int _userID;
        private clsUser _user;
        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrlAddUpdateUser1.ValidateInput())
            {
                MessageBox.Show("Either one of the fields is empty or the password is not confirmed","Faild to save"
                    ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(_user == null) {_user = new clsUser();}

            _user.PersonID = ctrlAddUpdateUser1.SelectedPersonId;
            _user.UserName=ctrlAddUpdateUser1.UserName;
            _user.Password=ctrlAddUpdateUser1.Password;
            _user.IsActive = ctrlAddUpdateUser1.IsActive;

            if (_user.Save())
            {
                MessageBox.Show("User Saved Successfully","Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlAddUpdateUser1.FindPersonEnabled=false;
                lblFormMode.Text = "Edit User";
                ctrlAddUpdateUser1.PersonIDLabelText=_user.ID.ToString();
                ctrlAddUpdateUser1.Mode = ctrlAddUpdateUser.enfrmMode.Update;
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
           _user= clsUser.FindUserByUserID(_userID);

            if(_user != null)
            {
                ctrlAddUpdateUser1.LoadUserControl(_user);
                ctrlAddUpdateUser1.FindPersonEnabled = false;
                lblFormMode.Text = "Update User";
                ctrlAddUpdateUser1.Mode=ctrlAddUpdateUser.enfrmMode.Update;
            }
        }

  
    }
}
