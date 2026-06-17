using DVLD.LDLApp;
using DVLD.Lıcences;
using DVLD.Licences;
using DVLD.Licences.DetainedLicences;
using DVLD.Lıcences.InternatıonalLıcense;
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
    public partial class frmMainMenu : Form
    {
        //private frmManagePeople _frmManagePeople;
        //private frmManageUsers _frmManageUsers;
        //private frmApplicationTypes _frmApplicationTypes;
        //private frmTestTypes _frmTestTypes;
        //private frmManageLDLApp _frmManageLDLApp;
        //private frmManageDrivers _frmManageDrivers;
        //private frmManageInternationalLicenses _frmManageIntLicenses;
        //private frmManageDetaınedLıcenses _frmManageDetainedLicenses;
        //private frmLogin _frmLogin;
        // ---------- JWT Token (HIGH) ----------
string jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.abcdefghijk123456789.xyz123456789abcdef";

// ---------- SendGrid API Key (CRITICAL) ----------
string sendGrid = "SG.1234567890123456789012.abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNO123456";

// ---------- Connection String (HIGH) ----------
string conn = "postgres://admin:SuperSecret123@localhost:5432/mydb";

// ---------- Hardcoded Password (HIGH) ----------
string password = "MyStrongPassword123";

// ---------- Generic API Key Assignment (HIGH) ----------
string api_key = "ABCDEF1234567890ABCDEF1234567890";

// ---------- Private Key Header (CRITICAL) ----------
string privateKeyHeader = "-----BEGIN RSA PRIVATE KEY-----";

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
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
         frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
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
            frmApplicationTypes frm = new frmApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frm = new frmTestTypes();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLApp frm = new frmManageLDLApp();
             frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLApp frm = new frmAddUpdateLDLApp(-1); 
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses frm = new frmManageInternationalLicenses();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm = new frmRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForDamagedOrLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseReplacementForLostOrDamaged frm = new frmLicenseReplacementForLostOrDamaged();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetaınedLıcense frm = new frmReleaseDetaınedLıcense();
            frm.ShowDialog();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmManageDetaınedLıcenses frm = new frmManageDetaınedLıcenses();
            frm.ShowDialog();
        }
    }
}
