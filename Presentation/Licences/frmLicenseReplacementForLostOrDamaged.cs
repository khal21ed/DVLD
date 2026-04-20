using Business;
using DVLD.LDLApp;
using System;
using System.Windows.Forms;

namespace DVLD.Licences
{
    public partial class frmLicenseReplacementForLostOrDamaged : Form
    {
        private clsApplication _application;
        private clsLicense _oldLicense;
        private clsLicense _newLicense;
        private clsApplicationTypes.enApplicatoinType _appType;
        private clsLicense.enIssueReason _issueReason;
        public frmLicenseReplacementForLostOrDamaged()
        {
            InitializeComponent();
        }

        private void _SetAppTypeAndIssueReason()
        {
            if(rbDamagedLicense.Checked)
            {
                _appType = clsApplicationTypes.enApplicatoinType.ReplacementForDamagedDL;
                _issueReason = clsLicense.enIssueReason.ReplacementForDamaged;
            }
            else
            {
                _appType=clsApplicationTypes.enApplicatoinType.ReplacementForLostDL;
                _issueReason = clsLicense.enIssueReason.ReplacementForLost;
            }
        }

        private void _FillApplication()
        {
            _application.ApplicantPersonID = clsPerson.GetPersonIDByDriverID(_oldLicense.DriverID);
            _application.Status = clsApplication.enApplicationStatus.Completed;
            _application.PaidFees = clsApplicationTypes.GetApplicatoinTypeFee(_appType);
            _application.ApplicatoinDate = DateTime.Now;
            _application.CreatedByUser = clsSessoin.CurrentUser.ID;
            _application.LastStatusDate = DateTime.Now;
            _application.ApplicationTypeID = (int)_appType;

        }

        private void _FillNewLicenseInfo()
        {
            _newLicense.DriverID = _oldLicense.DriverID;
            _newLicense.LicenseClassID = _oldLicense.LicenseClassID;
            _newLicense.IssueDate = DateTime.Now;
            _newLicense.ExpirationDate = DateTime.Now.AddYears
                (clsLicenseClass.GetLicenseClassValidatyLength(_oldLicense.LicenseClassID));
            _newLicense.PaidFees = clsLicenseClass.GetLicenseClassFees(_oldLicense.LicenseClassID) ;
            _newLicense.IsActive = true;
            _newLicense.IssueReason = _issueReason;
            _newLicense.CreatedByUserID = clsSessoin.CurrentUser.ID;
        }

        private void _SetFormStateAfterSaving()
        {
            lblAppID.Text = _application.ID.ToString();
            lblNewLicenseID.Text = _newLicense.ID.ToString();
            btnIssue.Enabled = false;
            llNewLicenseInfo.Enabled = true;
            ctrlLicensePicker1.FindLicenseEnabeled = false;
            gbReplacement.Enabled = false;
        }

        private void ctrlLicensePicker1_OnLicenseSelected(int obj)
        {
            _oldLicense = clsLicense.FindLicenseByID(obj);
            if (_oldLicense == null)
            {
               llLicenseHistory.Enabled = false;
                lblOldLocalLicenseID.Text = "???";
                btnIssue.Enabled = false;
                return;
            }

            llLicenseHistory.Enabled = true;
            lblOldLocalLicenseID.Text = _oldLicense.ID.ToString();

            btnIssue.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!_oldLicense.IsActive)
            {
                MessageBox.Show("You license is inactive please activate it first", "Faild",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SetAppTypeAndIssueReason();
            _application = new clsApplication();
            _FillApplication();

            if (!_application.AddNewApplication())
            {
                MessageBox.Show("An Error occured the application couldn't be saved", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _newLicense = new clsLicense();
            _FillNewLicenseInfo();
            _newLicense.ApplicationID = _application.ID;

            if (_newLicense.IssueLicense(_application.ApplicantPersonID))
            {
                MessageBox.Show($"Your license renewed successfully with ID={_newLicense.ID}", "License Renewed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _oldLicense.DeactivateLicense();
                _SetFormStateAfterSaving();
                return;
            }
            else
            {
                MessageBox.Show("An error occured while issuing the license", "Faild to Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void frmLicenseReplacementForLostOrDamaged_Load(object sender, EventArgs e)
        {
            _SetAppTypeAndIssueReason();
            lblAppDate.Text = clsGlobal.FormatDate(DateTime.Now);
            lblAppFees.Text = clsApplicationTypes.GetApplicatoinTypeFee(_appType).ToString();
            lblCreatedByUser.Text = clsSessoin.CurrentUser.UserName;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _SetAppTypeAndIssueReason();
            lblAppFees.Text=clsApplicationTypes.GetApplicatoinTypeFee(_appType).ToString();
        }

        private void llNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfoCard frm = new frmLicenseInfoCard(_newLicense.ID);
            frm.ShowDialog();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = clsPerson.GetPersonIDByDriverID(_oldLicense.DriverID);
            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
