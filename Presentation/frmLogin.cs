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
    // =====================================================
// ENTROPY TESTS
// =====================================================

// Should trigger: High-Signal Entropy Assignment
string secret = "7fG93ksA92LmP8vQsK2n";

// Should trigger: High-Signal Entropy Assignment
string token = "Ab8xP92mLsQ8kT1vWzR3";

// Should ideally trigger: MEDIUM entropy
string key = "abcdef123456abcdef";

// Should ideally trigger: HIGH entropy
string credential = "mN8zQ2xL9vB7kJ1pR4sT6uW";

// Should trigger: High-Signal Entropy Assignment
string privateToken = "L8mQ2zX7cV9nB1kR4tY6";

// Same value without keyword context
string value = "L8mQ2zX7cV9nB1kR4tY6";

// Entropy stress test
string randomSecret = "aB9xK2mQ7rT5uV8wX1yZ3nP6";
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
