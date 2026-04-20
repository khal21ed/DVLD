using Business;
using DVLD.LDLApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Lıcences
{
    public partial class frmRenewLicense : Form
    {
        private clsLicense _oldLicense;
        private clsLicense _newLicense;
        private clsApplication _application;
        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private void _FillApplication()
        {
            _application.ApplicantPersonID = clsPerson.GetPersonIDByDriverID(_oldLicense.DriverID);
            _application.Status = clsApplication.enApplicationStatus.New;
            _application.PaidFees = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.RenewDrivingLicense);
            _application.ApplicatoinDate = DateTime.Now;
            _application.CreatedByUser = clsSessoin.CurrentUser.ID;
            _application.LastStatusDate = DateTime.Now;
            _application.ApplicationTypeID = (int)clsApplicationTypes.enApplicatoinType.RenewDrivingLicense;

        }

        private void _FillNewLicenseInfo()
        {
            _newLicense.DriverID= _oldLicense.DriverID;
            _newLicense.LicenseClassID= _oldLicense.LicenseClassID;
            _newLicense.IssueDate=DateTime.Now;
            _newLicense.ExpirationDate= DateTime.Now.AddYears
                (clsLicenseClass.GetLicenseClassValidatyLength(_oldLicense.LicenseClassID));
            _newLicense.Notes = txtNotes.Text;
            _newLicense.PaidFees = clsLicenseClass.GetLicenseClassFees(_oldLicense.LicenseClassID);
            _newLicense.IsActive= true;
            _newLicense.IssueReason = clsLicense.enIssueReason.Renew;
            _newLicense.CreatedByUserID=clsSessoin.CurrentUser.ID;
        }

        private void ctrlLicensePicker1_OnLicenseSelected(int obj)
        {

            _oldLicense = clsLicense.FindLicenseByID(obj);
            if (_oldLicense == null)
            {
                llLicenseHistory.Enabled = false;
                lblLicenseFees.Text = "???";
                lblTotalFees.Text = "???";
                lblLocalLicenseID.Text = "???";
                btnRenew.Enabled = false;
                return;
            }

            lblLicenseFees.Text=_oldLicense.PaidFees.ToString();
            lblTotalFees.Text=(Convert.ToInt32(lblLicenseFees.Text)+Convert.ToInt32(lblAppFees.Text)).ToString();
            llLicenseHistory.Enabled = true;
            lblExpirationDate.Text= DateTime.Now.AddYears
                (clsLicenseClass.GetLicenseClassValidatyLength(_oldLicense.LicenseClassID)).ToString();
            lblLocalLicenseID.Text = _oldLicense.ID.ToString();

            if(_oldLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("Your license is not expired yet, it has to be expired to be able to renew it",
                    "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true ;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (!_oldLicense.IsActive)
            {
                MessageBox.Show("You license is inactive please activate it first", "Faild",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _application = new clsApplication();
            _FillApplication();

            if (!_application.AddNewApplication())
            {
                MessageBox.Show("An Error occured the application couldn't be saved", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _newLicense=new clsLicense();
            _FillNewLicenseInfo();
            _newLicense.ApplicationID = _application.ID;

            if (_newLicense.IssueLicense(_application.ApplicantPersonID))
            {
                MessageBox.Show($"Your license renewed successfully with ID={_newLicense.ID}", "License Renewed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _oldLicense.DeactivateLicense();
                btnRenew.Enabled = false;
                llNewLicenseInfo.Enabled = true;
                ctrlLicensePicker1.FindLicenseEnabeled = false;
                return;
            }
            else
            {
                MessageBox.Show("An error occured while issuing the license","Faild to Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }


        }

        private void llNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfoCard frm = new frmLicenseInfoCard(_newLicense.ID);
            frm.ShowDialog();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID= clsPerson.GetPersonIDByDriverID(_oldLicense.DriverID);
            frmLicenseHistory frm=new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            
            lblIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblAppFees.Text = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.RenewDrivingLicense).ToString();
            lblCreatedByUser.Text = clsSessoin.CurrentUser.UserName;
        }
    }
}
