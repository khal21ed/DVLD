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
using System.IO;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user= clsUser.GetUserByUserNameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim());

            if (user == null) 
            {
                MessageBox.Show("Invalid Username/Password","Faild",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if (user.IsActive == false)
            {
                MessageBox.Show("This User is Inactive, Please contact your admin", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsSessoin.CurrentUser = user;

            if (cbRememberMe.Checked)
            {
                clsSessoin.CurrentUser.SaveUsernameAndPasswordToWinRegistory();
            }
            else
            {
                clsUser.DeleteSavedUserInWinRegistory();
            }

            //Close the Login Form and Go to the main menue
            clsSessoin.IsFirstLogin = false;
            DialogResult= DialogResult.OK;
            //this.Hide();
            //frmMainMenu frm = new frmMainMenu(this);
            //frm.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (clsUser.GetRememberedUserFromWinRegistory(out string loginInfo))
            {
               string[] loginSplited= loginInfo.Split(new string[] {clsUser.SavingToFileSeperator},StringSplitOptions.None);
                txtUserName.Text = loginSplited[0];
                txtPassword.Text = loginSplited[1];

                if (clsSessoin.IsFirstLogin)
                {

                    btnLogin_Click(null, null);
                }
            }

        }
    }
}
