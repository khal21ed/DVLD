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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Licences.DetainedLicences
{
    public partial class frmReleaseDetaınedLıcense : Form
    {
        private clsLicense _license;
        private clsDetainedLicense _detainedLicense;
        private clsApplication _application;
        private int _licenseID;
        public frmReleaseDetaınedLıcense(int licenseID=-1)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }
        private void _FillApplication()
        {
            _application.ApplicantPersonID = clsPerson.GetPersonIDByDriverID(_license.DriverID);
            _application.Status = clsApplication.enApplicationStatus.Completed;
            _application.PaidFees = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.ReleaseDetainedDrivingLicense);
            _application.ApplicatoinDate = DateTime.Now;
            _application.CreatedByUser = clsSessoin.CurrentUser.ID;
            _application.LastStatusDate = DateTime.Now;
            _application.ApplicationTypeID =
                (int)clsApplicationTypes.enApplicatoinType.ReleaseDetainedDrivingLicense;
        }

        
        private void ctrlLicensePicker1_OnLicenseSelected(int obj)
        {
            _license=clsLicense.FindLicenseByID(obj);
            if (_license == null)
            {
                btnRelease.Enabled = false;
                llLicenseHistory.Enabled = false;
                return;
            }
            llLicenseHistory.Enabled=true;
            lblLicenseID.Text=_license.ID.ToString();

            if (!clsLicense.IsLicenseDetaind(obj))
            {
                MessageBox.Show("The License you selected is not detained", "Not Detained License",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled=false;
                return;
            }

            _detainedLicense=clsDetainedLicense.Find(obj);
            lblDetainID.Text = _detainedLicense.DetainID.ToString();
            lblFineFees.Text= _detainedLicense.FineFees.ToString();
            lblDetainDate.Text = clsGlobal.FormatDate(_detainedLicense.DetainDate);
            lblTotalFees.Text = (_detainedLicense.FineFees + clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.ReleaseDetainedDrivingLicense)).ToString();
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _application = new clsApplication();
            _FillApplication();

            if(!_application.AddNewApplication())
            {
                MessageBox.Show("An error occured while saving the application", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _detainedLicense.ReleaseApplicationID = _application.ID;
            _detainedLicense.ReleaseDate = DateTime.Now;
            _detainedLicense.ReleasedByUserID = clsSessoin.CurrentUser.ID;

            if (_detainedLicense.ReleaseDetainedLicense())
            {
                MessageBox.Show("License was released successfully", "License Released",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRelease.Enabled = false;
                ctrlLicensePicker1.FindLicenseEnabeled = false;
                llShowReleasedLicenseInfo.Enabled = true;
                lblAppID.Text=_application.ID.ToString();
                return;
            }
            else
            {
                MessageBox.Show("An Error occured while releasing the license","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmReleaseDetaınedLıcense_Load(object sender, EventArgs e)
        {
            lblAppFees.Text = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.ReplacementForDamagedDL).ToString();
            lblCreatedByUser.Text=clsSessoin.CurrentUser.UserName;

            //Opened through the Managing Screen
            if (_licenseID != -1)
            {
                //Simulate that we entered the license ID and searched for it
                ctrlLicensePicker1.txtLicenseIDText = _licenseID.ToString();
                ctrlLicensePicker1.PerformSearchClick();
                ctrlLicensePicker1.FindLicenseEnabeled=false;
            }
        }

        private void llShowReleasedLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfoCard frm = new frmLicenseInfoCard(_license.ID);
            frm.ShowDialog();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = clsPerson.GetPersonIDByDriverID(_license.DriverID);
            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
