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
    public partial class frmChangeUserPassword : Form
    {
        private int userID = -1;
        private clsUser _user;
        public frmChangeUserPassword(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void _LoadUserInfo()
        {
             _user = clsUser.FindUserByUserID(userID);
            if (_user != null)
            {
                ctrlUserInfo1.LoadUser(_user);
            }
            else
            {
                MessageBox.Show("User wasn't found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            return (!string.IsNullOrWhiteSpace(txtCurrentPasswod.Text) &&
                !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtConfirmPassword.Text)
                && _user.Password == txtCurrentPasswod.Text && txtPassword.Text == txtConfirmPassword.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (_user.ChangePassword(txtPassword.Text))
                    MessageBox.Show("Password has changed successfully");
            }
            else
            {
                MessageBox.Show("Your inputs are not valid","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCurrentPasswod_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPasswod.Text))
            {
                epCheckInputs.SetError(txtCurrentPasswod, "This field shouldn't be empty");

            }
            else if (txtCurrentPasswod.Text != _user.Password)
            {
                epCheckInputs.SetError(txtCurrentPasswod, "The passwod doesn't match your current password");
            }
            else
            {
                epCheckInputs.SetError(txtCurrentPasswod, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epCheckInputs.SetError(txtPassword, "This field shouldn't be empty");

            }
            else
            {
                epCheckInputs.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epCheckInputs.SetError(txtConfirmPassword, "This field shouldn't be empty");

            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                epCheckInputs.SetError(txtConfirmPassword, "Confirm password doesn't match the new password");
            }
            else
            {
                epCheckInputs.SetError(txtConfirmPassword, "");
            }
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            _LoadUserInfo();
        }
    }
}
