using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMainMenue : Form
    {
        private frmManagePeople _frmManagePeople;
        private frmManageUsers _frmManageUsers;
        private frmChangeUserPassword _frmChangePassword;
        private frmShowUserInfo _frmShowUserInfo;
        private frmApplicationTypes _frmApplicationTypes;

        public frmMainMenue()
        {
            InitializeComponent();
            _frmManagePeople = new frmManagePeople();
            _frmManageUsers = new frmManageUsers();
            _frmApplicationTypes = new frmApplicationTypes();
          }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmManagePeople.IsDisposed||_frmManagePeople==null)
            {
                _frmManagePeople = new frmManagePeople();
            }
            _frmManagePeople.MdiParent = this;
            _frmManagePeople.Show();
        }

        private void frmMainMenue_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmManageUsers.IsDisposed || _frmManageUsers == null)
            {
                _frmManageUsers = new frmManageUsers();
            }

            _frmManageUsers.MdiParent = this;
            _frmManageUsers.Show();
        }

        private void showLogedinUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmShowUserInfo frm = new frmShowUserInfo(clsSessoin.CurrentUser.ID);
            frm.ShowDialog();

        }

        private void changeCurToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsSessoin.CurrentUser.ID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmApplicationTypes.IsDisposed || _frmApplicationTypes == null)
            {
                _frmApplicationTypes = new frmApplicationTypes();
            }
            _frmApplicationTypes.MdiParent = this;
            _frmApplicationTypes.Show();
        }
    }
}
