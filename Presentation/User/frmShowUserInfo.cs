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
    public partial class frmShowUserInfo : Form
    {
        private int userID=-1;
        public frmShowUserInfo(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void _LoadFormWithUserInfo()
        {
            clsUser user = clsUser.FindUserByUserID(userID);
            if (user != null)
            {
                ctrlUserInfo1.LoadUser(user);
            }
            else
            {
                MessageBox.Show("No User Was Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            _LoadFormWithUserInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
