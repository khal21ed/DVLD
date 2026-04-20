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
    public partial class ctrlAddUpdateUser : UserControl
    {

        public ctrlAddUpdateUser()
        {
            InitializeComponent();
        }
        public enum enfrmMode { Add = 0, Update = 1 }
        public enfrmMode Mode
        {
            get; set;
        }
        public int SelectedPersonId   // READ-ONLY FORWARDING
        {
            get
            {
                return ctrlPersonPicker1.SelectedPersonId;
            }
        }
        public bool FindPersonEnabled
        {
            get => ctrlPersonPicker1.FindPersonEnabled;
            set => ctrlPersonPicker1.FindPersonEnabled = value;
        }
        public string UserName => txtUserName.Text.Trim();
        public string Password => txtPassword.Text;
        public bool IsActive => chkIsActive.Checked;
        public string PersonIDLabelText { get=>lblUserIDValue.Text;set=>lblUserIDValue.Text=value ; }

        private bool _CheckIfPersonExistOrAlreadyAUser(out string message)
        {
            message = "";
            if (Mode == enfrmMode.Update) { return false; }

            if (ctrlPersonPicker1.SelectedPersonId == -1)
            {
                message = "Please select a person firs";
                return true;
            }

            if (clsUser.UserExistsByPersonID(ctrlPersonPicker1.SelectedPersonId))
            {
                message = "This person is already a user";
                return true;
            }
            return false;
        }
        public void Clear()
        {
            txtUserName.Text= string.Empty;
            txtPassword.Text= string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_CheckIfPersonExistOrAlreadyAUser(out string message))
            { 
            MessageBox.Show(message, "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
             }

            tcUserAddUpdate.SelectedIndex = 1;  

        }
        public void LoadUserControl(clsUser user)
        {
            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtConfirmPassword.Text=user.Password;
            lblUserIDValue.Text = user.ID.ToString();
            chkIsActive.Checked = user.IsActive;
            ctrlPersonPicker1.FindPersonAndLoadIntoPersonCard(this ,user.PersonID);

        }
        public bool ValidateInput()
        {
            return (!string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text)
                && !string.IsNullOrWhiteSpace(txtConfirmPassword.Text)&&txtPassword.Text==txtConfirmPassword.Text);
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                epCheckInputs.SetError(txtUserName, "UserName should not be empty");
            }
            else if (clsUser.UserExistsByUserName(txtUserName.Text))
                {
                
                epCheckInputs.SetError(txtUserName, "UserName already exists");                    
            }
            else
            {
                epCheckInputs.SetError(txtUserName, "");
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                epCheckInputs.SetError(txtPassword, "Password should not be empty");
            }
            else
            {
                epCheckInputs.SetError(txtPassword, "");
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                epCheckInputs.SetError(txtConfirmPassword, "Confirm Password should not be empty");
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                epCheckInputs.SetError(txtConfirmPassword, "Confirm Password must match the password");

            }
            else
            {
                epCheckInputs.SetError(txtConfirmPassword, "");
            }
        }
        private void tcUserAddUpdate_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpUserInfo) //when we want to navigate from Person info to User info
            {
                if (_CheckIfPersonExistOrAlreadyAUser(out string message))
                    e.Cancel = true;
            }
        }
        private void ctrlAddUpdateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
